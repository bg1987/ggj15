using UnityEngine;
using System.Collections;

public class IgnoreCollision : MonoBehaviour {



    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Enter");
            //Physics2D.IgnoreCollision(other, this.GetComponent<BoxCollider2D>(), true);
            GetComponent<SmoothFollow>().canMoveBack = false;
        }
    
    }

    public void OnTriggerExit2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
        Debug.Log("Exit");
            //Physics2D.IgnoreCollision(other, this.GetComponent<BoxCollider2D>(), false);
            GetComponent<SmoothFollow>().canMoveBack = true;

        }
    }

    
}
