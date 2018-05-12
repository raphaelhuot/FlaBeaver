using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnDestroyer : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Column")
        {
            Destroy(other.gameObject);
        }
    }
}
