using UnityEngine;
using System.Collections;

public class Fox : MonoBehaviour {

    public float speed = 1.0f;
    public float jump;
    Animator anim;

    //For WASD Movement
    bool canMoveWASD = false;

    // Animation Handlers
    bool isMoving;
    bool isKicking = false;
    bool isRotated = false;
    //jump? sorry Jess :p
    bool canJump = true;

    //  Kicking Handlers
    bool canKick = false; // allows the fox to kick
    bool kicked = false; // tests if the fox just kicked

    // For Locked Doors
    bool hasKey = false;
    bool canInteract = false;
    bool interacted = false;

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
        if (Input.GetKeyDown(KeyCode.E))
        {            
            //Kick
            if (canKick == true)
            {
                Kick();
            }
            else if (canInteract)
            {
                interacted = true;
            }
        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            isMoving = false;
        }

        if (!isMoving)
        {
            if (!isKicking)
            {
                anim.Play("Idle");
            }            
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (canMoveWASD)
        {
            if (Input.GetKey(KeyCode.W))
            {
                Move(new Vector3(0, 0, speed));
            }
            else if (Input.GetKey(KeyCode.S))
            {
                Move(new Vector3(0, 0, -speed));
            }
        }        
    }

    void Kick()
    {
        Rotate(); // Rotate Fox so he Kicks the Gate
        isKicking = true; // Keeps Idle Anim from Playing
        anim.Play("Kick"); // Plays Kicking Anim
        StartCoroutine(Wait("Kick")); // Wait for animation to play before opening the gate
    }

    void Rotate()
    {
        if (isRotated)
        {
            transform.Rotate(0, 180, 0);
            transform.GetChild(0).Rotate(0, 0, 180);
            isRotated = false;
        }
        else
        {
            transform.Rotate(0, 180, 0);
            transform.GetChild(0).Rotate(0, 0, 180);
            isRotated = true;
        }
    }

    void Move(Vector3 newPos)
    {
        transform.Translate(newPos * Time.deltaTime);
    }

    public void Interact(string interactName, GameObject interactObject)
    {
        if (interactName.Equals("Log"))
        {
            canKick = true;
            if (kicked == true)
            {
                interactObject.GetComponent<Log>().Interact();
                kicked = false;
            }
        }else if (interactName.Equals("Locked Gate"))
        {
            canInteract = true;
            if (interacted)
            {
                interactObject.GetComponent<Gate>().hasFoxKey = true;
                hasKey = false;
                interactObject.GetComponent<Gate>().Interact();
                interacted = false;
            }
        }
        else if (interactName.Equals("Kickable Gate"))
        {
            canKick = true;
            if (kicked == true)
            {
                interactObject.GetComponent<Gate>().Interact();
                kicked = false;
            }
        }
        else if (interactName.Equals("Axe"))
        {
            canKick = true;
            if (kicked == true)
            {
                interactObject.GetComponent<Axe>().Interact();
                kicked = false;
            }
        }
        else if (interactName.Equals("Platform"))
        {

        }
    }

    IEnumerator Wait(string action)
    {
        if (action.Equals("Kick"))
        {
            yield return new WaitForSeconds(0.4f); 
            kicked = true; // Object Gets Kicked
            isKicking = false; // No longer Kicking, Idle Anim can Play
            Rotate(); // Rotate Fox Back
            StartCoroutine(Wait("Stop Kicking"));
        }
        if (action.Equals("Jump") && canJump)
        {
            canJump = false;
            GetComponent<Rigidbody>().AddForce(1, jump, 1);
            yield return new WaitForSeconds(0.4f);
            GetComponent<Rigidbody>().AddForce(1, -jump * 1.5f, 1);
            yield return new WaitForSeconds(0.4f);
            canJump = true;
        }
    }

    void Jump()
    {
        StartCoroutine(Wait("Jump"));
    }
    
    public void StopInteraction()
    {
        canInteract = false;
        canKick = false;
    }

    // For Locked Gates
    public void PickUpKey()
    {
        hasKey = true;
    }

    //catapault add and remove parent
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Platform")
            transform.parent = other.transform;
        else
            return;
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Platform")
            transform.parent = null;
        else
            return;        
    }
    
    public void ToggleMovement(bool isUnlocked)
    {
        canMoveWASD = isUnlocked;
    } 

}
