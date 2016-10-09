using UnityEngine;
using System.Collections;

public class CatapaultArm : MonoBehaviour
{
    Animator anim;

    bool canInteract = false;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        catapault();
    }
    void OnCollisionEnter(Collider other)
    {
        if (other.tag == "Fox")
        {
            canInteract = true;
        }        
    }
    void OnTriggerExit(Collider other)
    {
        canInteract = false;
    }
    void catapault()
    {
        if (Input.GetKeyDown(KeyCode.E) && canInteract)
        {
            anim.Play("Arm");
        }
    }
}
