using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float ProjectileSpeed = 20.0f;

	// Use this for initialization
	void Start () {
        //rigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += (ProjectileSpeed * transform.up * Time.deltaTime);
	}
}
