using UnityEngine;
using System.Collections;

public class KillOnCollide : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag != "Player")
        {
            return;
        }

        Camera.main.GetComponent<GameController>().KillPlayer(true);
    }


}
