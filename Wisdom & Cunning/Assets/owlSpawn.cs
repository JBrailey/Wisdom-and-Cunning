using UnityEngine;
using System.Collections;

public class owlSpawn : MonoBehaviour {

    public GameObject owl;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Fox")
            owl.SetActive(true);        
    }
}
