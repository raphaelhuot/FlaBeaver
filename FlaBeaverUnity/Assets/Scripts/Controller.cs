using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    public MicrophoneScript mic;
    public GameObject beaver;
    private Rigidbody2D beaverRB;
    public GameObject bird;
    private Animator anim;

    private void Start()
    {
        beaverRB = beaver.GetComponent<Rigidbody2D>();
        anim = bird.GetComponent<Animator>();
    }
    private void Update()
    {
        if (mic.loudness > 8)
        {
            beaverRB.velocity = new Vector2(beaverRB.velocity.x, 1 + (mic.loudness/4));
            anim.SetTrigger("Flap");
        }
    }
}
