using UnityEngine;
using System.Collections;

public class Lever : MonoBehaviour
{

    public GameObject interactedObject;
    Animator anim;
    bool switched = false;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        gameObject.tag = "Interact";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Interact()
    {
        Debug.Log("Lever.Interact Called");
        PullLever();
        if (switched == false)
        {
            anim.Play("Lever");
            switched = true;
        }
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
