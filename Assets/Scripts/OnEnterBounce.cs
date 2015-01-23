using UnityEngine;
using System.Collections;

public class OnEnterBounce : MonoBehaviour {

    public float jumpForce = 50f;

    public void OnEnter(GameObject player)
    {
        player.rigidbody2D.AddForce(Vector2.up * jumpForce);
    }
}
