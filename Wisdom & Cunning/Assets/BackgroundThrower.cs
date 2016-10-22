using UnityEngine;
using System.Collections;

public class BackgroundThrower : MonoBehaviour {

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
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Fox")
        {
            other.attachedRigidbody.useGravity = false;
            canInteract = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        other.attachedRigidbody.useGravity = true;
        canInteract = false;
    }

    void catapault()
    {
        if (Input.GetKeyDown(KeyCode.E) && canInteract)
        {
            
            anim.Play("Background Thrower");
        }
        else
            return;
    }
}
