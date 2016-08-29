using UnityEngine;
using System.Collections;

public class Interact : MonoBehaviour {

    public string objectName;


	// Use this for initialization
	void Start () {
        gameObject.tag = "Interact";
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag.Equals("Fox"))
        {
            // Tell Fox Object was interacted with
            collider.gameObject.GetComponent<Fox>().Interact(objectName, gameObject);
        }
        else if (collider.gameObject.tag.Equals("Owl"))
        {
            // Tell Owl Object was Interacted With
            collider.gameObject.GetComponent<Owl>().Interact(objectName, gameObject);
        }
    }
}
