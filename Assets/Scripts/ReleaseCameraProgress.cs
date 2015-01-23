using UnityEngine;
using System.Collections;

public class ReleaseCameraProgress : MonoBehaviour {

    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag != "Player")
        {
            return;
        }

        Camera.main.GetComponent<SmoothFollow>().StopMovement = false;
    }
}
