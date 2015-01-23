using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public PlayerControl player;
	public MsgsPanel msgsPanel;
    public CheckpointManager checkpoint;

	enum TutorialState {WelcomeMsg,ControlMsg,Play}
	TutorialState tutorialState = TutorialState.WelcomeMsg;

	// Use this for initialization
	void Start () {
		msgsPanel.onShowMsgsCompleteEvent+= OnShowMsgsComplete;
		StartGame();
	}

	void StartGame(){
		//DoWelcomeMsg();
		FreePlay();
	}

	void DoWelcomeMsg(){
		tutorialState = TutorialState.WelcomeMsg;
		msgsPanel.AddMsg("Welcome to super Ivan cousions");
		msgsPanel.AddMsg("I am ivan");
		msgsPanel.AddMsg("Press left and right to move left and right");
	}

	void OnShowMsgsComplete ()
	{
		switch(tutorialState){
		case TutorialState.WelcomeMsg:
			DoControllMsg();
			break;
		case TutorialState.ControlMsg:
			FreePlay();
			break;
		}

	}

	void DoControllMsg(){
		tutorialState= TutorialState.ControlMsg;
		player.controlState= PlayerControl.ControlStates.MoveInPlace;
		Invoke("ShowControlMsg",4f);
	}

	void ShowControlMsg(){
		msgsPanel.AddMsg("ho, sorry, please let me fix that...");
		msgsPanel.AddMsg("coding...coding...coding...redbull...coding...comit...publish...");
		msgsPanel.AddMsg("ok try now");
	}

	void FreePlay ()
	{
		tutorialState= TutorialState.Play;
		player.controlState= PlayerControl.ControlStates.Free;
	}

    public void KillPlayer(bool resetVelocity = false)
    {
        player.transform.position = checkpoint.checkpoint.position;
        if (resetVelocity)
        {
            player.rigidbody2D.velocity = Vector3.zero;
        }
    }

	// Update is called once per frame
	void Update () {


	}
}
