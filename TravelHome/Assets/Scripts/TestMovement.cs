using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    /// <summary>
    /// ignore this entire script it is class work
    /// </summary>
    // Start is called before the first frame update
    public Rigidbody rigid;
    public float speed = 5f;
    public LayerMask ignoreLayer;

    // Update is called once per frame
    void LateUpdate()
    {
        
        float inputH = Input.GetAxisRaw("Horizontal");
        float inputV = Input.GetAxisRaw("Vertical");
       
        if (inputH != 0 && inputV != 0)
            return;
        if (Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical"))
        {
            Vector3 direction = Vector3.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position, 1f);
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
