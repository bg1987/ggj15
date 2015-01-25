using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {


    public GameObject TitleScreen;

	public PlayerControl player;
	public MsgsPanel msgsPanel;
    public CheckpointManager checkpoint;
    public bool ShowTutorial = false;

    private bool startGame = false;

	enum TutorialState {WelcomeMsg,ControlMsg,Play}
	TutorialState tutorialState = TutorialState.WelcomeMsg;
    
	// Use this for initialization
	void Start () {
		msgsPanel.onShowMsgsCompleteEvent+= OnShowMsgsComplete;
		StartGame();
	}

	void StartGame(){
        if (ShowTutorial)
        {
            TitleScreen.SetActive(true);
            StartCoroutine(TitleCoro());
		    //DoWelcomeMsg();
        }
        else
        {
            FreePlay();
        }
	}

	void DoWelcomeMsg(){
		tutorialState = TutorialState.WelcomeMsg;
        msgsPanel.AddMsg("Hello, Welcome to SUPER IVAN COUSINS! By Ivan.");
        msgsPanel.AddMsg("This is Ivan, top game developer");
        msgsPanel.AddMsg("Click left and right arrows to move left and right.");
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
        msgsPanel.AddMsg("Oh, Im sorry, Ivan fix.");
        msgsPanel.AddMsg("coding... coding... coding... redull... commit... publish...");
        msgsPanel.AddMsg("Ok, Now working.");
        msgsPanel.AddMsg("Follow Sign please.");
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
        if (Input.GetButton("Jump"))
        {
            startGame = true;
        }

	}

    IEnumerator TitleCoro()
    {
        while (!startGame)
        {
            yield return null;
        }
        TitleScreen.SetActive(false);
        DoWelcomeMsg();
    }
}
