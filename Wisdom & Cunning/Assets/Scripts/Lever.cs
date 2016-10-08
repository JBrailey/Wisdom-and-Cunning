using UnityEngine;
using System.Collections;

public class Lever : MonoBehaviour {

    public GameObject interactedObject;
    Animation anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animation>();
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
        anim.Play("Lever");
        // Insert Other Objects Here
    }
 
}
