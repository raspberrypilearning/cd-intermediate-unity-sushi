using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyLaser : MonoBehaviour {

    PlayerController playerScript;
    Text displayedScore;

	// Use this for initialization
	void Start () {
        playerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        displayedScore = GameObject.Find("Score").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Asteroid"))
        {
            AudioSource audio = GameObject.Find("AsteroidExplosion").GetComponent<AudioSource>();
            audio.Play();
            // Destroy both objects
            Destroy(col.gameObject);
            Destroy(gameObject);
            playerScript.score += 1;
            displayedScore.text = "Score: " + playerScript.score.ToString();
        }
    }
}
