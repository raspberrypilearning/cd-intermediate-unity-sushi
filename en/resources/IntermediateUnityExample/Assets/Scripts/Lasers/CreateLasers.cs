using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateLasers : MonoBehaviour {
    public GameObject laser;
    public GameObject player;
    public float laserSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 createPosition = player.transform.position;
            createPosition.y += 1f;
            // Create a laser clone
            GameObject laserClone = Instantiate(laser, createPosition, transform.rotation);
            laserClone.AddComponent<DestroyLaser>();
            // Make the clone move
            Rigidbody laserRB = laserClone.GetComponent<Rigidbody>();
            laserRB.velocity = transform.up * laserSpeed;
        }
	}
}
