using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PathDefenition : MonoBehaviour {
    public Transform[] points;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public IEnumerator<Transform> GetPathEnumarator()
    {
        if (points == null || points.Length < 1)
        {
            yield break;
        }

        int direction = -1;
        int index = 0;

        while (true)
        {
            yield return points[index];
            if (points.Length == 1)
            {
                continue;
            }

            if (index <= 0 || index >= points.Length -1)
            {
                direction *= -1;
            }

            index = index + direction;

        }
    }

    public void OnDrawGizmos()
    {
        if (points == null || points.Length <2)
        {
            return;
        }

        for (int i = 1; i < points.Length; i++)
        {
            Gizmos.DrawLine(points[i - 1].position, points[i].position);
        }
    }

    
}
