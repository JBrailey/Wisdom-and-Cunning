using UnityEngine;
using System.Collections;

public class Catapault : MonoBehaviour {
    Animator anim;
    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}
    void catapault(Collision collision)
    {
        if (collision.transform.tag == "CatapaultBox")
        {
            anim.Play("Catapault");
        }
    }
}
