using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour {

    private Rigidbody2D rb;
    public Bird player;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (!player.isDead)
        {
            rb.velocity = new Vector2(-1.5f, transform.position.y);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }

        if (transform.position.x <= -80.6)
        {
            transform.position = new Vector2(38.8f, transform.position.y);
        }
    }
}
