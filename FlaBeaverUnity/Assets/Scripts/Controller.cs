using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour {

    public MicrophoneScript mic;
    public GameObject beaver;
    private Rigidbody2D beaverRB;
    public GameObject bird;
    private Animator anim;

    public Image panelImage;
    public ColumnPool spawner;
    public Bird playerScript;
    public GameObject gameOver;

    private void Start()
    {
        beaverRB = beaver.GetComponent<Rigidbody2D>();
        anim = bird.GetComponent<Animator>();
    }
    private void Update()
    {
        if (mic.loudness > 8 && !playerScript.isDead)
        {
            beaverRB.velocity = new Vector2(beaverRB.velocity.x, 1 + (mic.loudness / 4));
            anim.SetTrigger("Flap");
        }
        
        if(playerScript.isDead)
        {
            gameOver.SetActive(true);
        }

        if (panelImage.isActiveAndEnabled)
        {
            beaver.SetActive(false);
            spawner.enabled = false;
        }
        else
        {
            beaver.SetActive(true);
            spawner.enabled = true;
        }

    }
}
