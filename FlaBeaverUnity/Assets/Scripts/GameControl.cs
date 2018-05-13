using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {
    public static GameControl Instance;
    public float scrollSpeed = -1.5f;
    public bool isGameOver = false;
    private int score = 0;

    public Text scoreText;
    public GameObject gameOverText;
	// Use this for initialization
	void Awake () {
		if (Instance == null)
        {
            Instance = this;
        } else if (Instance != this)
        {
            Destroy(gameObject);
        }
	}

    // Update is called once per frame
    public void Score() {
        if (isGameOver) { return; }
        score++;
        scoreText.text = "Score: " + score;
	}
    public void die()
    {
        isGameOver = true;
        gameOverText.SetActive(true);
    }
}
