using UnityEngine;
using System.Collections;

public class Fox : MonoBehaviour {

    public GameObject keyManager;

    public float speed = 1.0f;
    public float jump;
    Animator anim;

    //For WASD Movement
    bool canMoveWASD = false;

    // Animation Handlers
    bool isMoving;
    bool isKicking = false;
    bool isRotated = false;
    bool canJump = true;

    //  Kicking Handlers
    bool canKick = false; // allows the fox to kick
    bool kicked = false; // tests if the fox just kicked

    // Interaction Handlers
    bool canInteract = false;
    bool interacted = false;

    //Rotations
    Vector3 up = new Vector3(0, -90, 0);
    Vector3 down = new Vector3(0, -270, 0); //-270
    Vector3 left = new Vector3(0, 180, 0);
    Vector3 right = new Vector3(0, 0, 0);

    Vector3 camUp = new Vector3(90, 0, 90);
    Vector3 camDown = new Vector3(90, 0, 270);
    Vector3 camLeft = new Vector3(90, 0, 0);
    Vector3 camRight = new Vector3(90, 0, -180);


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

        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.D))
            {
                transform.eulerAngles = right;
                Transform camera = transform.GetChild(0);
                camera.transform.eulerAngles = camLeft;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                transform.eulerAngles = left;
                Transform camera = transform.GetChild(0);
                camera.transform.eulerAngles = camLeft;
            }

            if (!isMoving)
            {
                isMoving = true;
                anim.Play("Run");
            }
            Move(new Vector3(speed, 0, 0));
        }
        else if (canMoveWASD)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            {
                if (Input.GetKey(KeyCode.W))
                {
                    transform.eulerAngles = up;
                    Transform camera = transform.GetChild(0);
                    camera.transform.eulerAngles = camLeft;
                }
                else if (Input.GetKey(KeyCode.S))
                {
                    transform.eulerAngles = down;
                    Transform camera = transform.GetChild(0);
                    camera.transform.eulerAngles = camLeft;
                }

                if (!isMoving)
                {
                    isMoving = true;
                    anim.Play("Run");
                }
                Move(new Vector3(speed, 0, 0));
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {            
            //Kick
            if (canKick)
            {
                Kick();
            }
            else if (canInteract)
            {
                interacted = true;
            }
        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.W)|| Input.GetKeyUp(KeyCode.S))
        {
            isMoving = false;
        }

        //Check if Idle
        if (!isMoving)
        {
            if (!isKicking)
            {
                anim.Play("Idle");
            }            
        }

        // Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }             
    }

    void Kick()
    {
        transform.Rotate(0, 180, 0); // Rotate Fox so he Kicks the Gate
        transform.GetChild(0).Rotate(0, 0, 180); // Make Camera not Rotate
        isKicking = true; // Keeps Idle Anim from Playing
        anim.Play("Kick"); // Plays Kicking Anim
        StartCoroutine(Wait("Kick")); // Wait for animation to play before opening the gate
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
            if (kicked)
            {
                interactObject.GetComponent<Log>().Interact();
                kicked = false;
            }
        }
        else if (interactName.Equals("Locked Gate"))
        {
            canInteract = true;
            if (interacted)
            {
                // Uses Keys
                keyManager.GetComponent<KeyManager>().UseKeys(interactObject);
                interactObject.GetComponent<Gate>().Interact();
                interacted = false;
            }
        }
        else if (interactName.Equals("Kickable Gate"))
        {
            canKick = true;
            if (kicked)
            {
                interactObject.GetComponent<Gate>().Interact();
                kicked = false;
            }
        }
        else if (interactName.Equals("Axe"))
        {
            canKick = true;
            if (kicked)
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
            transform.Rotate(0, 180, 0); // Rotate Fox Back
            transform.GetChild(0).Rotate(0, 0, 180); // Make Camera not Rotate
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
        kicked = false;
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
