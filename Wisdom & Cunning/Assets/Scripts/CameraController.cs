﻿using UnityEngine;
using System.Collections;


public class CameraController : MonoBehaviour {
  
    public Transform target;
    public float distance;
    public float lift;

	// Update is called once per frame
	void Update ()
    {
        Vector3 offset = new Vector3(-2f, lift, distance);

        transform.position = target.position + offset;
        //transform.LookAt(target);      
	}
}
