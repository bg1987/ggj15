using UnityEngine;
using System.Collections;

public class OnEnterKill : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnEnter(GameObject player)
    {
        Camera.main.GetComponent<GameController>().KillPlayer();
    }
}
