using UnityEngine;
using System.Collections;

public class CatapaultArm : MonoBehaviour
{
    Animator anim;
    AudioSource boing;

    bool canInteract = false;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        boing = GetComponent<AudioSource>();
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
            canInteract = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Fox")
        {
            canInteract = false;
        }
    }

    void catapault()
    {
        if (Input.GetKeyDown(KeyCode.E) && canInteract)
        {            
            anim.Play("Arm");
            boing.Play();
        }
        else
            return;
    }
}
