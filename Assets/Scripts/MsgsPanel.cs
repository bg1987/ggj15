using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class MsgsPanel : MonoBehaviour {

	public Text msgTxt;

	List<string> _msgs = new List<string>();

	bool _isShowing=false;

	public event Action onShowMsgsCompleteEvent;

	void Awake(){
		gameObject.SetActive(false);
	}

	public void AddMsg(string msg){
		_msgs.Add(msg);

		if(!_isShowing){
			msgTxt.text="";
			_isShowing=true;
			ShowNextMsg();
		}

	}

	void ShowNextMsg(){
		StopCoroutine("WriteTxtCoro");
		gameObject.SetActive(true);
		StartCoroutine("WriteTxtCoro");
	}

	IEnumerator WriteTxtCoro(){

		if(_msgs.Count==0){
			if(onShowMsgsCompleteEvent!=null)
				onShowMsgsCompleteEvent();

			_isShowing=false;

			Hide();
			yield return null;
		}

		while(_msgs.Count>0){
			msgTxt.text="";
			string msg = _msgs[0];
			_msgs.RemoveAt(0);
			for (int i = 0; i < msg.Length; i++) {
				msgTxt.text+=msg[i];
				
				yield return new WaitForSeconds(0.08f);
			}
			if(_msgs.Count>0)
				yield return new WaitForSeconds(1.5f);
		}
		_isShowing=false;

		if(onShowMsgsCompleteEvent!=null)
			onShowMsgsCompleteEvent();

		yield return new WaitForSeconds(2f);

		Hide();

	}

	void Update(){
		if(Input.GetButtonDown("Jump") && _isShowing){
			ShowNextMsg();
		}
	}

	public void Hide(){
		gameObject.SetActive(false);
	}

}
