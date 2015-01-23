using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class MsgsPanel : MonoBehaviour {

	public Text msgTxt;

	List<string> _msgs = new List<string>();
	string _currentMsg="";
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

		if(_msgs.Count==0){
			if(onShowMsgsCompleteEvent!=null)
				onShowMsgsCompleteEvent();
			_isShowing=false;
			Hide();
		}

		StopCoroutine("WriteTxtCoro");
		gameObject.SetActive(true);
		StartCoroutine("WriteTxtCoro");
	}

	IEnumerator WriteTxtCoro(){



		while(_msgs.Count>0){
			msgTxt.text="";
			_currentMsg = _msgs[0];
			_msgs.RemoveAt(0);
			for (int i = 0; i < _currentMsg.Length; i++) {
				msgTxt.text+=_currentMsg[i];
				
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
			if(_currentMsg!=""){
				msgTxt.text=_currentMsg;
				_currentMsg="";
			}
			else
				ShowNextMsg();
		}
	}

	public void Hide(){
		gameObject.SetActive(false);
	}

}
