using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AIMovement : MonoBehaviour
{
    //define the player and its navmesh
    public Transform player;
    // Start is called before the first frame update
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void OnDrawGizmos()
    {
       //adds a gizmo to make the movement more streamlined 
        Gizmos.color = Color.cyan;
        Vector3 direction = agent.path.corners[1] - transform.position;
        
        Gizmos.DrawCube(transform.position + direction.normalized * 1f, Vector3.one * .5f);
    }
    // Update is called once per frame
    void LateUpdate()
    {
        //makes it so that the movement goes to the closeiest so you don't have to deal with being stuck on the corners
        float inputH = Input.GetAxisRaw("Horizontal");
        float inputV = Input.GetAxisRaw("Vertical");
       
        //makes it so if there is input then it activates the thing
        if (inputH != 0 && inputV != 0)
            return;
        //makes the enemy stop so they don't move towars the player
        agent.SetDestination(player.position);
        agent.isStopped = true;

        if (Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical"))
        {
            //  the enemies move towards the character
            agent.isStopped = false;
            Vector3 direction = agent.path.corners[1] - transform.position;
            direction.Normalize();
            direction.x = Mathf.Round(direction.x);
            direction.y = Mathf.Round(direction.y);
            direction.z = Mathf.Round(direction.z);
            agent.Move(direction * 1f);
            
        }
    }
}
