using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class MsgsPanel : MonoBehaviour {

	public Text msgTxt;

	List<string> _msgs = new List<string>();

	bool _isShowing=false;

	void Start(){
		gameObject.SetActive(false);
	}

	public void AddMsg(string msg){
		gameObject.SetActive(true);

		_msgs.Add(msg);

		if(!_isShowing){
			msgTxt.text="";
			_isShowing=true;
			StartCoroutine("WriteTxtCoro");
		}

	}

	IEnumerator WriteTxtCoro(){
		while(_msgs.Count>0){
			msgTxt.text="";
			string msg = _msgs[0];
			_msgs.RemoveAt(0);
			for (int i = 0; i < msg.Length; i++) {
				msgTxt.text+=msg[i];
				
				yield return new WaitForSeconds(0.08f);
			}
			yield return new WaitForSeconds(2f);
		}
		_isShowing=false;
	}

	public void Hide(){
		gameObject.SetActive(false);
	}

}
