using UnityEngine;
using System.Collections;


public class CameraController : MonoBehaviour {
  
    public Transform target;
    public float distance;
    public float lift;
    public float xPos;


	// Update is called once per frame
	void Update ()
    {
        Vector3 offset = new Vector3(xPos, lift, distance);
        Vector3 newPos = target.position + offset;
        newPos.z = distance;
        transform.position = newPos;    
	}
}
