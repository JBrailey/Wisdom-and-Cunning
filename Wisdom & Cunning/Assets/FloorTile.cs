﻿using UnityEngine;
using System.Collections;

public class FloorTile : MonoBehaviour {

    public GameObject floor;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("HeavyBox"))
            floor.SetActive(true);
    }
}
