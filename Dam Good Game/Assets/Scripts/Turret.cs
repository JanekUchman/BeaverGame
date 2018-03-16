using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    public float DetectionDistance = 10.0f;
    public float RotationRate = 10.0f;
    public float FiringRate = 2.0f;
    public LayerMask DetectionLayer;

    private bool knockedOut = false; 

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void DetectTarget()
    {
        // Create circle collider that finds all the objects within the radius
        Collider2D[] DetectedColliders = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y), DetectionDistance, DetectionLayer, -Mathf.Infinity, Mathf.Infinity);
        // Check if the collider has detected a ship that is nearby
        if (DetectedColliders.Length > 0)
        {
            // create variable to determine what ship is closest to the turret
            float closestDistance;
            for (int i = 0; i < DetectedColliders.Length; i++)
            {

            }
        }
    }

}
