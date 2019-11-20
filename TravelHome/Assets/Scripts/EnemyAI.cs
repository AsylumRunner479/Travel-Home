using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform waypointParent;
    public float waypointDistance = 5f;
    public float speed = 5f;

    private Transform[] points;
    private int currentWaypoint = 1;
    void Start()
    {
        points = waypointParent.GetComponentsInChildren<Transform>();
    }
    private void OnDrawGizmos()
    {
        if (points != null)
        {
            Gizmos.color = Color.red;
            for (int i = 1; i < points.Length - 1; i++)
            {
                Transform pointA = points[i];
                Transform pointB = points[i + 1];
                Gizmos.DrawLine(pointA.position, pointB.position);

            }
            for (int i = 1; i < points.Length; i++)
            {
                Gizmos.DrawSphere(points[i].position, waypointDistance);
            }
        }
    }

    void Update()
    {   // Get the current waypoint
        float inputH = Input.GetAxisRaw("Horizontal");
        float inputV = Input.GetAxisRaw("Vertical");

        if (Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical"))
        {
            Transform currentPoint = points[currentWaypoint];
            // Move towards current waypoint
            transform.position = Vector3.MoveTowards(transform.position, currentPoint.position, 1f);
            // Check if distance between waypoint is close
            float distance = Vector3.Distance(transform.position, currentPoint.position);
            if (distance < waypointDistance)
            {
                currentWaypoint++;
            }
            
        }
    }
}
