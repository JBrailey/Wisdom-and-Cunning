using UnityEngine;
using System.Collections;

public class Lever : MonoBehaviour {

    public GameObject interactedObject;

	// Use this for initialization
	void Start () {
        gameObject.tag = "Interact";
    }
	
	// Update is called once per frame
	void Update () {

	}

    public void Interact()
    {
        Debug.Log("Lever.Interact Called");
        PullLever();
    }

    void PullLever()
    {
        if (interactedObject.tag.Equals("Gate"))
        {
            interactedObject.GetComponent<Gate>().Interact();
        }

        // Insert Other Objects Here
    }
}
