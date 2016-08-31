﻿using UnityEngine;
using System.Collections;

public class Owl : MonoBehaviour {

    // On Left Mouse Click (Look up "Input" in scripting API), create a Raycast at Mouse click location.
    // Check it the object it hits (if any) tag = "Interact" if yes get the objects position and move to it.
    // Make a "Return to Fox" Class.

    public GameObject foxObject;

    public float speed;
    public float heightAboveFox;
    bool isMoving = false;
    bool returningToFox = false;
    bool atFox = true;
    Vector3 newPosition;

    
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

    void WaitForClick()
    {
        // Left Mouse Button Pressed
        if (Input.GetMouseButton(0))
        {
            // Raycast Stuff
        }
    }

    public void Interact(string interactName, GameObject interactObject)
    {
        // e.g if Object is called Lever
        if (interactName.Equals("Lever"))
        {
            //interactObject.getComponent<Lever>.flip
        }
    }

    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, newPosition, speed * Time.deltaTime);
    }

}
