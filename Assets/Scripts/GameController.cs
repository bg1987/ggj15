using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public PlayerControl player;
	public MsgsPanel msgsPanel;


	// Use this for initialization
	void Start () {
		msgsPanel.AddMsg("Hello, i am ivan, welcome to super ivan cousions");
		msgsPanel.AddMsg("press left and right to move left and right");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
