using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentImpulse : MonoBehaviour {

    public float ImpulseRadius = 10.0f;
    public float ImpulseForce = 10.0f;
    public LayerMask ForceLayer;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            // Update position
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // Apply new impulse
            TriggerImpulse();
        }
    }


    void TriggerImpulse()
    {
        // Create circle collider that interacts with all objects near the impulse
        Collider2D[] ImpulseCollisions = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y), ImpulseRadius, ForceLayer, -Mathf.Infinity, Mathf.Infinity);
        for(int i = 0; i < ImpulseCollisions.Length; i++)
        {
            Debug.Log("hit argument");
            // Check if the object has a rigidbody attached to it - needs force applied to it
            if(ImpulseCollisions[i].GetComponent<Rigidbody2D>())
            {
                // Reset velocity of the object being effected by the current
                ImpulseCollisions[i].GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                // Direction that the force should be applied in = position of force - position of the object
                Vector2 ForceVector = (ImpulseCollisions[i].transform.position - transform.position) * ImpulseForce;
                // Apply force to the object at the point of overlap
                ImpulseCollisions[i].GetComponent<Rigidbody2D>().AddForce(ForceVector);
            }
        }
    }
}
