using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    public MicrophoneScript mic;
    public GameObject beaver;
    private Rigidbody2D beaverRB;

    private void Start()
    {
        beaverRB = beaver.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (mic.loudness > 8)
        {
            beaverRB.velocity = new Vector2(beaverRB.velocity.x, 4);
        }
    }
}
