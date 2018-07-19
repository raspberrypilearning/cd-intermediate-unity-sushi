using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateAsteroids : MonoBehaviour {

    public GameObject asteroid;
    public float asteroidSpeed;

    public float creationTime = 1f;

    // Use this for initialization
    void Start()
    {
        // 0f is when to start invoking repeat
        InvokeRepeating("createAsteroid", 0f, creationTime);
    }
	
	// Update is called once per frame
	void createAsteroid () {
        //Vector3 createPosition = Vector3.zero;
        Vector3 createPosition = getRandomPosition();
        GameObject asteroidClone = Instantiate(asteroid, createPosition, asteroid.transform.rotation);

        // make the asteroid move
        Rigidbody asteroidCloneRB = asteroidClone.GetComponent<Rigidbody>();
        asteroidCloneRB.velocity = -(transform.up * asteroidSpeed);
	}

    Vector3 getRandomPosition()
    {
        float xPos = Random.Range(.05f, .95f);
        Vector3 randomPosition = Camera.main.ViewportToWorldPoint(new Vector3(xPos, 1.1f, 15f));
        return randomPosition;
    }
}
