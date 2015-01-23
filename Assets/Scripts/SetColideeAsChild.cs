using UnityEngine;
using System.Collections;

public class SetColideeAsChild : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnCollisionEnter2D(Collision2D coll)
    {
        OnCollisionStay2D(coll);
    }
    
    public void OnCollisionStay2D(Collision2D coll)
    {

        coll.collider.gameObject.transform.parent = transform;
    }

    public void OnCollisionExit2D(Collision2D coll)
    {
        coll.collider.gameObject.transform.parent = null;
    }



}
