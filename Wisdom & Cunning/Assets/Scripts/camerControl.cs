using UnityEngine;
using System.Collections;


public class camerControl : MonoBehaviour {
  
    public Transform target;
    public static float distance = -10.0f;
    public static float lift = 2.5f;
    private Vector3 offset = new Vector3(0.0f, lift, distance);

	// Update is called once per frame
	void Update ()
    {
        transform.position = target.position + offset;
        transform.LookAt(target);      
	}
}
