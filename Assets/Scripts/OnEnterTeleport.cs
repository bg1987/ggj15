using UnityEngine;
using System.Collections;

public class OnEnterTeleport : MonoBehaviour {
    public Transform location;
	
    public void OnEnter(GameObject player)
    {
        player.transform.position = location.position;
    }
}
