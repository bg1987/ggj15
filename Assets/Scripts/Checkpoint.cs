using UnityEngine;
using System.Collections;
using System;

public class Checkpoint : MonoBehaviour {
    public CheckpointManager manager;
 	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("checkpoint: "+other.gameObject);
        if (other.tag != "Player")
        {
            return;
        }
        manager.SetCheckpoint(transform);
        
    }

    
}
