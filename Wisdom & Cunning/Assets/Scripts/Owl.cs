using UnityEngine;
using System.Collections;


public class Owl : MonoBehaviour
{

    public Transform followPoint;
    public Transform goTo;
    public GameObject arrow;
    public Camera camera;

    public Vector3 canReturn = new Vector3(1, 0, 0);
    public float turnSpeed;
    public float speed;

    public int layerMask = 1<<50;

    bool returningToFox = false;


    // For Locked Gate
    bool hasKey = false;

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
        Follow();
        WaitForClick();
    }

    void Follow()
    {
        if (returningToFox)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(followPoint.position - transform.position), Time.deltaTime * turnSpeed);
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
        else if (interactName.Equals("Locked Gate"))
        {
            interactObject.GetComponent<Gate>().hasOwlKey = true;
            hasKey = false;
            interactObject.GetComponent<Gate>().Interact();
        }else if (interactName.Equals("Crossbow"))
        {
            interactObject.GetComponent<Crossbow>().Interact();
        }
    }

    void Move(Transform GoTo)
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(GoTo.position - transform.position), turnSpeed * Time.deltaTime);
        transform.position += transform.forward * speed * Time.deltaTime;
        canReturn = transform.position - GoTo.position;
        if (canReturn.x <= 1 && canReturn.x > -1)
        {
            returningToFox = true;
        }
        // transform.position = Vector3.MoveTowards(transform.position, newPosition, speed * Time.deltaTime);
    }

    public void PickUpKey()
    {
        hasKey = true;
    }

    public bool HasKey()
    {
        if (hasKey)
        {
            return true;
        }
        return false;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "BearTrap")
        {
            arrow.SetActive(false);

        }
    }
}
