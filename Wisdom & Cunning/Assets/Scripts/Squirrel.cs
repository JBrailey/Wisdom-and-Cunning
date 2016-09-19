using UnityEngine;
using System.Collections;

public class Squirrel : MonoBehaviour {

    public bool asleep;

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update () {
	    if (asleep == false)
        {
            GetComponent<BoxCollider>().enabled = false;
        }
        else
        {
            GetComponent<BoxCollider>().enabled = true;
        }
	}

    public void Interact(int State)
    {
        Debug.Log("Squirrel.Interact Called");
        if (State == 1)
        {
            Debug.Log("Squirrel Woken");
            asleep = false;
        }
        else if (State == 2)
        {
            Debug.Log("Squirrel Sent to Sleep");
            asleep = true;
        }
    }
}
