using UnityEngine;
using System.Collections;

public class EnterableChecker : MonoBehaviour {
    private GameObject collided;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Vertical") < 0f && collided != null)
        {
            collided.gameObject.SendMessage("OnEnter", this.gameObject);
        }
	}

    public void OnCollisionEnter2D(Collision2D coll)
    {
        collided = coll.gameObject;
    }

    public void OnCollisionExit2D(Collision2D coll)
    {
        collided = null;
    }

    

}
