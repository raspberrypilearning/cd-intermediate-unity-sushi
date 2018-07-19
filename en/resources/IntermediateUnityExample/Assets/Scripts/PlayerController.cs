using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public int score;
    Text endgameText;

	// Use this for initialization
	void Start () {
        Cursor.visible = false;
        score = 0;
        endgameText = GameObject.Find("WinOrLose").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 15f;
        transform.position = Camera.main.ScreenToWorldPoint(mousePos);
        Vector3 spritePos = Camera.main.WorldToViewportPoint(transform.position);
        spritePos.x = Mathf.Clamp(spritePos.x, 0.05f, 0.95f);
        spritePos.y = Mathf.Clamp(spritePos.y, 0.1f, 0.9f);
        transform.position = Camera.main.ViewportToWorldPoint(spritePos);

        if (score == 10)
        {
            endGame("You Win!");
        }
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Asteroid(Clone)")
        {
            AudioSource audio = GameObject.Find("PlayerExplosion").GetComponent<AudioSource>();
            audio.Play();
            Destroy(gameObject);
            Destroy(col.gameObject);
            endGame("GAME OVER");
        }
    }

    void endGame(string text)
    {
        endgameText.text = text;
        Time.timeScale = 0;
    }
}
