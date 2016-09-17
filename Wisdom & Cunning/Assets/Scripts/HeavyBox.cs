using UnityEngine;
using System.Collections;

public class HeavyBox : MonoBehaviour
{
    public GameObject invisibleWall;
    
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
        if (collision.gameObject.tag.Equals("Projectile"))
        {
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().AddForce(1, -4000, 1);
            invisibleWall.SetActive(false);
        }
    }
}