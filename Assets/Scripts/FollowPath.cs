using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FollowPath : MonoBehaviour {
    public enum FollowType
    {
        Lerp, MoveTowards
    }

    public FollowType Type = FollowType.MoveTowards;
    public PathDefenition path;
    public float speed = 1.0f;
    public float maxDistanceToGoal = 0.1f;

    private IEnumerator<Transform> _currentPoint;
	// Use this for initialization
	void Start () {
        if (path == null)
        {
            Debug.LogError("No path to follow for Follow path script");
            return;
        }

        _currentPoint = path.GetPathEnumarator();
        _currentPoint.MoveNext();

        if (_currentPoint.Current == null)
        {
            return;
        }

        transform.position = _currentPoint.Current.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (_currentPoint == null || _currentPoint.Current == null)
        {
            return;
        }

        if (Type == FollowType.MoveTowards)
        {
            transform.position = Vector3.MoveTowards(transform.position, _currentPoint.Current.position, Time.deltaTime * speed);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, _currentPoint.Current.position, Time.deltaTime * speed);
        }

        var distSquared = (transform.position - _currentPoint.Current.position).sqrMagnitude;
        if (distSquared < maxDistanceToGoal* maxDistanceToGoal)
        {
            _currentPoint.MoveNext();
        }
	}
}
