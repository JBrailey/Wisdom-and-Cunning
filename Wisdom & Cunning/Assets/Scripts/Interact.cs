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
        Debug.Log("T R I G G E R E D");

        if (collider.gameObject.tag.Equals("Fox"))
        {
            Debug.Log("Fox hit by Trigger");
            if (objectName.Equals(""))
            {
                // Tell Fox Object was interacted with
                collider.gameObject.GetComponent<Fox>().Interact(objectName, gameObject);
                Debug.Log("Fox told object name and object");
            }
            else
            {
                //collider.isTrigger = true;
            }          
        }
        else if (collider.gameObject.tag.Equals("Owl"))
        {
            if (objectName.Equals("Lever"))
            {
                // Tell Owl Object was Interacted With
                collider.gameObject.GetComponent<Owl>().Interact(objectName, gameObject);
            }else
            {
                //collider.isTrigger = true;
            }                      
        }
    }
}
