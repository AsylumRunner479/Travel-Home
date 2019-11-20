using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rigid;
    public float speed = 5f;
    public LayerMask ignoreLayer;

    // Update is called once per frame
    void LateUpdate()
    {
        //defines the inputs as rough so you don't collison issues
        float inputH = Input.GetAxisRaw("Horizontal");
        float inputV = Input.GetAxisRaw("Vertical");
       
        if (inputH != 0 && inputV != 0)
            return;
        if (Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical"))
        {
            //makes the player move one in a direction of their choice if it doesn't collide with a wall
            Vector3 direction = new Vector3(inputH, 0, inputV);
            Vector3 position = transform.position + direction;
            Collider[] hits = Physics.OverlapBox(position, Vector3.one * 0.1f, transform.rotation, ~ignoreLayer, QueryTriggerInteraction.Ignore);
            if (hits.Length == 0)
            {
                // If position + direction is not colliding with overlap sphere
                // Before moving position
                transform.position += direction;
            }
            
        }
    }
}
