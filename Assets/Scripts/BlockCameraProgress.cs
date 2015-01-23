using UnityEngine;
using System.Collections;

public class BlockCameraProgress : MonoBehaviour {


    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject);
        if (other.gameObject.tag != "Player" )
        {
            return;
        }

        Camera.main.GetComponent<SmoothFollow>().StopMovement = true;
    }
}
