using UnityEngine;
using System.Collections;

public class PlayerStuck : MonoBehaviour {

	public MsgsPanel msgsPanel;
	Vector3 _lastPos;
	float _timeCount=0;
	PlayerControl _player;
	bool _isStack=false;

	// Use this for initialization
	void Start () {
		_player=GetComponent<PlayerControl>();
		_lastPos=gameObject.transform.position;

	}
	
	// Update is called once per frame
	void Update () {

		if(_player.controlState!=PlayerControl.ControlStates.Free)
			return;

		if(_lastPos==gameObject.transform.position)
			_timeCount+=Time.deltaTime;
		else{
			_lastPos=gameObject.transform.position;
			_timeCount=0;
			_isStack=false;
		}

		if(_timeCount>15){
			_timeCount=0;
			_isStack=true;
			msgsPanel.Reset();
			msgsPanel.AddMsg("It seem you broke game, press R to fix");
		}

		if(_isStack){
			_timeCount=0;
			if(Input.GetKey(KeyCode.R)){
				_isStack=false;
				msgsPanel.Reset();
				Camera.main.GetComponent<GameController>().KillPlayer();
			}

		}



	}
}
