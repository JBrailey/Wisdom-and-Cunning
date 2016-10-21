using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour {

    GameObject keyManager;
	
	// Update is called once per frame
	void Update () {
        transform.RotateAround(transform.position, new Vector3(0, 1, 0), 2);
	}

    void OnTriggerEnter(Collider col)
    {
        keyManager.GetComponent<KeyManager>().PickUpKey(1);       
    }
}
