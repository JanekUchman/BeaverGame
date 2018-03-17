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
        DetectTarget();
	}

    void DetectTarget()
    {
        // Create circle collider that finds all the objects within the radius
        Collider2D[] DetectedColliders = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y), DetectionDistance, DetectionLayer, -Mathf.Infinity, Mathf.Infinity);
        // Check if the collider has detected a ship that is nearby
        Debug.Log(DetectedColliders.Length);
        if (DetectedColliders.Length > 0)
        {
            // Create variable to determine what ship is closest to the turret
            float closestDistance = Mathf.Infinity;
            for (int i = 0; i < DetectedColliders.Length; i++)
            {
				// Determine the distance between the collider and the turret
				float curDistance = Vector2.Distance(transform.position, DetectedColliders[i].transform.position);
                // Check if the current collider is closer to the previous
                if(curDistance < closestDistance)
                {
                    // Set this to be the closest distance
                    closestDistance = curDistance;
                    // Create vector that determines the new direction our object wants to be facing
                    Vector2 lookDirection = (DetectedColliders[i].transform.position - transform.position).normalized;
                    // Get the angle that we need to rotate to face the object
                    float lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
                    // Convert that to quaternion for rotation
                    Quaternion lookRotation = Quaternion.AngleAxis(lookAngle, transform.forward);
                    // Rotate the object over time
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, Time.deltaTime * RotationRate);
                }
            }
        }
    }

}
