using UnityEngine;
using System.Collections;

public class CheckpointManager : MonoBehaviour {

    public Transform checkpoint;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}


    public void SetCheckpoint(Transform ckpt)
    {
        Debug.Log("SetCheckpoint: " + ckpt);

        checkpoint = ckpt;
    }
}
