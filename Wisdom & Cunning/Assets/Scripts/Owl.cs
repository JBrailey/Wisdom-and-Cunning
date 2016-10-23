using UnityEngine;
using System.Collections;


public class Owl : MonoBehaviour
{
    public Transform followPoint;
    public Transform goTo;
    public GameObject arrow;
    public Camera camera;
    public Transform fox;

    public Vector3 canReturn = new Vector3(1, 0, 0);
    public float turnSpeed;
    public float speed;
    public float foxDistance;
    public float goToDistance;
    private float Accelerate;
    private bool inMaze = false;
    public Vector3 flyUp = new Vector3(0,1,0);
    public Vector3 flydown = new Vector3(0.035f, 0.5f, 0.07600006f);

    public int layerMask = 1<<50;

    bool returningToFox = false;

    // For Locked Gate
    public GameObject keyManager;

    //TODO 

    // Use this for initialization
    void Start()
    {
        gameObject.tag = "Owl";
        followPoint = GameObject.FindGameObjectWithTag("FollowPoint").transform;
        returningToFox = true;
        layerMask = Physics.DefaultRaycastLayers & ~LayerMask.GetMask("UI");
    }

    // Update is called once per frame
    void Update()
    {
        foxDistance = Vector3.Distance(transform.position, followPoint.position);
        Accelerate = (speed + foxDistance) /2.5f;
        goToDistance = Vector3.Distance(transform.position, goTo.position);
        Follow();
        WaitForClick();
    }
    
    void Follow()
    {        
        
        if (returningToFox)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(followPoint.position - transform.position), Time.deltaTime * turnSpeed);
            if (Accelerate < speed)
            {
                Accelerate = speed;
            }
            transform.position += transform.forward * Accelerate * Time.deltaTime;
        }
        if(returningToFox && inMaze == true)
        {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(followPoint.position - transform.position), Time.deltaTime * turnSpeed);
            if (Accelerate < speed)
            {
                Accelerate = speed;
            }
            followPoint.position += flyUp;
            transform.position += transform.forward * Accelerate * Time.deltaTime;
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
        else if (interactName.Equals("Locked Gate"))
        {
            // Uses Keys
            keyManager.GetComponent<KeyManager>().UseKeys(interactObject);
        }
        else if (interactName.Equals("Crossbow"))
        {
            interactObject.GetComponent<Crossbow>().Interact();
        }
    }

    void Move(Transform GoTo)
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(GoTo.position - transform.position), turnSpeed * Time.deltaTime);
        if (Accelerate< speed)
        {
            Accelerate = speed;
        }
        transform.position += transform.forward * Accelerate * Time.deltaTime;
        canReturn = transform.position - GoTo.position;
        //if (canReturn.x <= 1 && canReturn.x > -1)
        if (goToDistance<5)
        { 
            returningToFox = true;
        }
      
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "BearTrap")
        {
            arrow.SetActive(false);
        }
        if (other.transform.tag == "Maze Entry")
        {
            inMaze = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Maze Entry")
        {
            followPoint.transform.position = fox.transform.position + flydown;
            inMaze = false;
        }
    }
}
