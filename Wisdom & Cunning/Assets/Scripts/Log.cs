using UnityEngine;
using System.Collections;

public class Log : MonoBehaviour {

    public GameObject interactedObject;
    Vector3 gravity = new Vector3(0, 4, 0);
    Vector3 vectorKicked = new Vector3(100, 20, 0);
    bool LogKicked = false;

    // Use this for initialization
    void Start () {
        gameObject.tag = "Interact";
    }
	
	// Update is called once per frame
	void Update () {

        if (LogKicked == true)
        {
            transform.Translate(vectorKicked * Time.deltaTime);
        }

        //  Gravity
        if (transform.position.y != 2)
        {
            transform.Translate(gravity * Time.deltaTime);
        }
        else
        {
            LogKicked = false;
        }
        
	}

    public void Interact()
    {
        Debug.Log("Log.Interact Called");
        GetKicked();
    }
    
    void GetKicked()
    {
        LogKicked = true;
    }
}
