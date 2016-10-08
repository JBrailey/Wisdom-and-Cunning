using UnityEngine;
using System.Collections;

public class SeeSaw : MonoBehaviour
{

    Animator anim;
    public GameObject fox;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fox.transform.position.x > transform.position.x)
        {
            anim.Play("SeeSaw");
        }
        else if (fox.transform.position.x < transform.position.x)
        {
            anim.Play("SawSee");
        }

    }
}
