using UnityEngine;
using System.Collections;

public class SeeSaw : MonoBehaviour
{
    Animator anim;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        anim.Play("Catapault");
        anim.Play("SeeSaw");
    }
}