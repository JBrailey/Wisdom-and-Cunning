using UnityEngine;
using System.Collections;

public class SeeSaw : MonoBehaviour
{
    Animator anim;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void seeSaw()
    {
        if (1 == 1)
        {
            anim.Play("SeeSaw");
        }
    }
}