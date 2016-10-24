using UnityEngine;
using System.Collections;

public class Lever : MonoBehaviour
{

    public GameObject interactedObject;
    Animator anim;
    AudioSource leverFX;

    bool switched = false;

    // Use this for initialization
    void Start()
    {
        leverFX = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        gameObject.tag = "Interact";
    }

    public void Interact()
    {
        Debug.Log("Lever.Interact Called");
        PullLever();
    }

    void PullLever()
    {
        leverFX.Play();
        if (interactedObject.tag.Equals("Gate"))
        {
            interactedObject.GetComponent<Gate>().Interact();
        }
    }
}
