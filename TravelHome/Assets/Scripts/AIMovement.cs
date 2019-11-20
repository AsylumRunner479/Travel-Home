using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AIMovement : MonoBehaviour
{
    //defines the player as an object 
    public Transform player;
    // Start is called before the first frame update
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //makes the input rough
        float inputH = Input.GetAxisRaw("Horizontal");
        float inputV = Input.GetAxisRaw("Vertical");

        if (inputH != 0 && inputV != 0)
            return;
        //stops the agent when the input isn't activating
        agent.SetDestination(player.position);
        agent.isStopped = true;

        if (Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical"))
        {
            //moves the agent with the input to the player
            agent.isStopped = false;
            if (agent.path != null && agent.path.corners.Length > 0)
            {
                Vector3 direction = agent.path.corners[1] - transform.position;
                direction.Normalize();
                direction.x = Mathf.Round(direction.x);
                direction.y = Mathf.Round(direction.y);
                direction.z = Mathf.Round(direction.z);
                agent.Move(direction * 1f);
            }
            
        }
    }
}
