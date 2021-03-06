﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour {
    public float spawnRate = 4f;
    public int columnPoolSize = 1000;
    public float columnYMin = -2f;
    public float columnYMax = 2f;
    public GameObject spawner;

    private float timeSinceLastSpawn;
    private float spawnXPos = 4f;
    private int currentColumn = 0;

    public GameObject columnPrefab;

    private GameObject[] columns;
    private Vector2 objectPoolPosition;
	// Use this for initialization
	void Start () {
        objectPoolPosition = new Vector2(20f, -25f);
        columns = new GameObject[columnPoolSize];
        for(int i = 0; i <columnPoolSize; i++)
        {
            columns[i] = (GameObject)Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity);
        }
	}
	
	// Update is called once per frame
	void Update () {
        timeSinceLastSpawn += Time.deltaTime;

        if(!GameControl.Instance.isGameOver && timeSinceLastSpawn >= spawnRate)
        {
            timeSinceLastSpawn = 0;
            float spawnYPos = Random.Range(columnYMin, columnYMax);
            columns[currentColumn].transform.position = new Vector2(-1f, spawnYPos);

            currentColumn++;

            if(currentColumn >= columnPoolSize)
            {
                currentColumn = 0;
            }
        }
	}
}
