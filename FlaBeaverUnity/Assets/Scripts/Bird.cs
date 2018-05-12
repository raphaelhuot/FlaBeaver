using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {
    public bool isDead = false;

    private Rigidbody2D rb2d;
    private Animator anim;
    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D()
    {
        Debug.Log("Suck it");
        isDead = true;
        rb2d.velocity = Vector2.zero;
        anim.SetTrigger("Die");
        GameControl.Instance.die();
    }
}
