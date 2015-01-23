﻿using UnityEngine;
using System.Collections;

public class SmoothFollow : MonoBehaviour
{

    public float dampTime = 0.15f;
    private Vector3 velocity = Vector3.zero;
    public Transform target;
    public float maxRight = 0;
    public bool followY =false;
    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            Vector3 point = camera.WorldToViewportPoint(target.position);
            Vector3 delta = target.position - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
            delta.x = delta.x > 0 ? 0 : delta.x;
            if (!followY)
            {
                delta.y = 0;
            }
            Vector3 destination = transform.position + delta;
            //destination.x = destination.x > maxRight ? maxRight : destination.x;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }

    }
}