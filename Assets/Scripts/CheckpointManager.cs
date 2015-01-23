using UnityEngine;
using System.Collections;

public class CheckpointManager : MonoBehaviour {

    private Transform checkpoint;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}



    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != "Player")
        {
            return;
        }

        other.gameObject.transform.position = checkpoint.position;
    }


    public void SetCheckpoint(Transform ckpt)
    {
        Debug.Log("SetCheckpoint: " + ckpt);

        checkpoint = ckpt;
    }
}
