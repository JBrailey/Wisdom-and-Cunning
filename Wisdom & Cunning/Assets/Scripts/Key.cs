using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour {

    public GameObject keyManager;
  
	// Update is called once per frame
	void Update () {
        transform.RotateAround(transform.position, new Vector3(0, 1, 0), 2);
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Fox" || col.tag == "Owl")
        {
            
            keyManager.GetComponent<KeyManager>().PickUpKey(1);
            gameObject.SetActive(false);
            
        }
    }
}
