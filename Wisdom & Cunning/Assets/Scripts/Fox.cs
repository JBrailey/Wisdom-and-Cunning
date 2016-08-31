using UnityEngine;
using System.Collections;

public class Fox : MonoBehaviour {

    public float speed = 1.0f;
    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        CheckKeyPress();
    }

    void CheckKeyPress()
    {
        // Movement
        if (Input.GetKey(KeyCode.D)) // Forward
        {
            Move(new Vector3(0, speed, 0));
        }
        else if (Input.GetKey(KeyCode.A)) // Backward
        {
            Move(new Vector3(0, -speed, 0));
        }



    }

    void Move(Vector3 newPos)
    {
        transform.Translate(newPos * Time.deltaTime);
    }

    public void Interact(string interactName, GameObject interactObject)
    {
        // e.g if Object is called Lever
        if (interactName.Equals("Lever"))
        {
            //interactObject.getComponent<Lever>.flip
        }
    }
}
