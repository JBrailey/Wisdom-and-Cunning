using UnityEngine;
using System.Collections;

public class catapault_boxes : MonoBehaviour
{
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
            GetComponent<Rigidbody>().AddForce(1, 1, -4000);
    }
}