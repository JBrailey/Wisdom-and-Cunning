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

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Fox")
        {
            canInteract = true;
        }
        else
            return;
    }
    void catapault()
    {
        if (Input.GetKeyDown(KeyCode.E) && canInteract)
        {
            anim.Play("Arm");
        }
    }
}
