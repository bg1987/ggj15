using UnityEngine;
using System.Collections;

public class TutorialMessage : MonoBehaviour {
    public string[] Messages;
    public MsgsPanel messageQueue;
    public bool forceMessage;
    public bool oneTime = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (forceMessage)
        {
            messageQueue.Reset();
        }

        foreach (var msg in Messages)
        {
            messageQueue.AddMsg(msg);
        }

        if (oneTime)
        {
            gameObject.SetActive(false);
        }
    }


}
