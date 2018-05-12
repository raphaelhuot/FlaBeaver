using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

    public Text gameTimerText;
    float gameTimer = 180f;
    public Bird player;

    private void Start()
    {
        if (PlayerPrefs.HasKey("GameTimer"))
        {
            gameTimer = PlayerPrefs.GetFloat("GameTimer");
        }
        else
        {
            gameTimer = 180f;
        }
    }

    // Update is called once per frame
    void Update () {
        if (!player.isDead)
        {
            gameTimer -= Time.deltaTime;
        }

        int seconds = (int)(gameTimer % 60);
        int minutes = (int)(gameTimer / 60) % 60;

        string timerString = string.Format("{0:0}:{1:00}", minutes, seconds);

        gameTimerText.text = timerString;
        PlayerPrefs.SetFloat("GameTimer", gameTimer);
		
	}
}
