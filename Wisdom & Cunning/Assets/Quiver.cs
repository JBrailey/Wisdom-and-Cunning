using UnityEngine;
using System.Collections;

public class Quiver : MonoBehaviour {
    public GameObject arrow;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Owl")
        {
            arrow.SetActive(true);
        }
    }
}
