using UnityEngine;
using System.Collections;

public class Fox : MonoBehaviour {

    public float speed = 1.0f;
    Animator anim;

    bool isMoving;
    bool canInteract;
    bool isRotated = false;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        gameObject.tag = "Fox";
	}
	
	// Update is called once per frame
	void Update () {
        CheckKeyPress();
    }

    void CheckKeyPress()
    {
        isMoving = false;
        // Movement
        if (Input.GetKey(KeyCode.D)) // Forward
        {
            Move(new Vector3(speed, 0, 0));

            if (isRotated)
            {
                Rotate();
            }
            if (!isMoving)
            {
                isMoving = true;
                anim.Play("Run");
            }    
        }
        else if (Input.GetKey(KeyCode.A)) // Backward
        {
            Move(new Vector3(speed, 0, 0));

            if (!isRotated)
            {
                Rotate();
            }
            if (!isMoving)
            {
                isMoving = true;
                anim.Play("Run");
            }
        }
        else if (Input.GetKey(KeyCode.E))
        {
            //Kick
        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            isMoving = false;
        }

        if (!isMoving)
        {
            anim.Play("Idle");
        }
    }

    void Rotate()
    {
        if (isRotated)
        {
            transform.Rotate(0, 180, 0);
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 7);
            isRotated = false;
        }else
        {
            transform.Rotate(0, 180, 0);
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 7);
            isRotated = true;
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
            Debug.Log("Interact Name is Lever");
            interactObject.GetComponent<Lever>().Interact();
        }
    }

    public void CanInteract()
    {
        canInteract = true;
    }
}
