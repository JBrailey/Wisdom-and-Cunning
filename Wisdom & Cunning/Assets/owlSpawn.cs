using UnityEngine;
using System.Collections;

public class owlSpawn : MonoBehaviour {

    public GameObject owl;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Fox")
            owl.SetActive(true);
    }
}
