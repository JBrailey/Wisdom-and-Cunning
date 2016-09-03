using UnityEngine;
using System.Collections;

public class Owl : MonoBehaviour {

    // On Left Mouse Click (Look up "Input" in scripting API), create a Raycast at Mouse click location.
    // Check it the object it hits (if any) tag = "Interact" if yes get the objects position and move to it.
    // Make a "Return to Fox" Class.

    
    public Transform followPoint;
    public Transform goTo;

    public Vector3 canReturn = new Vector3(1, 0, 0);

    public float turnSpeed;
    public float speed;

    public int layerMask = 1 << 5;

    bool isMoving = false;
    bool returningToFox = false;
    bool canInteract;
   
    //TODO 





    // Use this for initialization
    void Start ()
    {
        gameObject.tag = "Owl";
        followPoint = GameObject.FindGameObjectWithTag("FollowPoint").transform;
        returningToFox = true;
        layerMask = ~layerMask;

    }
	
	// Update is called once per frame
	void Update ()
    {
        Follow();
        WaitForClick();


    }

    void Follow()
    {
        if (returningToFox)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(followPoint.position - transform.position), turnSpeed * Time.deltaTime);
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        if (returningToFox == false)
            Move(goTo);
    }

    void WaitForClick()
    {
        //Left Mouse Button Pressed
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
                                                                                    //My overall idea here is to right click to fly to the object
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))                                 //when you are at the object, left click to use it.
            {
                Debug.DrawLine(ray.origin, hit.point);
                //Interact("Lever", GameObject.FindGameObjectWithTag("Interact"));//"Lever" here will be replaced with the game object name
            }
        }
        // Right Mouse Button Pressed
        if (Input.GetMouseButton(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                Debug.DrawLine(ray.origin, hit.point);
                returningToFox = false;
                goTo = hit.transform;
               
            }
        }
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

  

    void Move(Transform GoTo)
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(GoTo.position - transform.position), turnSpeed * Time.deltaTime);
        transform.position += transform.forward * speed * Time.deltaTime;
        if ((transform.position.x * transform.position.x) - (GoTo.position.x * GoTo.position.x) > canReturn.x)
        {
            returningToFox = true;
        }

        // transform.position = Vector3.MoveTowards(transform.position, newPosition, speed * Time.deltaTime);
    }

}
