using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour {

    public bool isOwlKey;
    public bool isFoxKey;

	// Use this for initialization
	void Start () {
        if (isFoxKey)
        {
            isOwlKey = false;
        }
        else if (isOwlKey)
        {
            isFoxKey = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
        transform.RotateAround(transform.position, new Vector3(0, 1, 0), 2);
	}

    void OnTriggerEnter(Collider col)
    {
        if (isFoxKey)
        {
            if (col.gameObject.tag.Equals("Fox"))
            {
                col.GetComponent<Fox>().PickUpKey();
                gameObject.SetActive(false);
            }
        }
        else if (isOwlKey)
        {
            if (col.gameObject.tag.Equals("Owl"))
            {
                col.GetComponent<Owl>().PickUpKey();
                gameObject.SetActive(false);
            }
        }
    }
}
