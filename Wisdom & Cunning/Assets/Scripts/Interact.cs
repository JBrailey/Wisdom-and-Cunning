using UnityEngine;
using System.Collections;

public class Interact : MonoBehaviour {

    public string objectName;

	// Use this for initialization
	void Start () {
        //gameObject.tag = "Interact";
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter(Collider collider) // Function fires upon entering a trigger collider
    {
        if (collider.gameObject.tag.Equals("Fox"))
        {
            // Fox Stuff?
        }
        else if (collider.gameObject.tag.Equals("Owl"))
        {
            if (objectName.Equals("Lever"))
            {
                collider.gameObject.GetComponent<Owl>().Interact(objectName, gameObject);               
            }
            else if (objectName.Equals("Locked Gate"))
            {
                collider.gameObject.GetComponent<Owl>().Interact(objectName, gameObject);
            }    
            else if (objectName.Equals("Crossbow"))
            {
                collider.gameObject.GetComponent<Owl>().Interact(objectName, gameObject);
            }              
        }
    }

    void OnTriggerStay(Collider collider) // Function fires for the duration an object is within a collider trigger
    {
        if (collider.gameObject.tag.Equals("Fox"))
        {
            if (objectName.Equals("Log"))
            {
                collider.gameObject.GetComponent<Fox>().Interact(objectName, gameObject);
            }
            else if (objectName.Equals("Kickable Gate"))
            {
                collider.gameObject.GetComponent<Fox>().Interact(objectName, gameObject);
            }
            else if (objectName.Equals("Locked Gate"))
            {
                collider.gameObject.GetComponent<Fox>().Interact(objectName, gameObject);
            }
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag.Equals("Fox"))
        {
            collider.gameObject.GetComponent<Fox>().StopInteraction();
        }
    }
}
