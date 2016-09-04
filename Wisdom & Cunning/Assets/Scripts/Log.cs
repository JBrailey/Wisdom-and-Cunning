using UnityEngine;
using System.Collections;

public class Log : MonoBehaviour {

    public GameObject interactedObject;
    Vector3 vectorKicked = new Vector3(5, -1, 0);
    
    bool LogKicked = false;

    public float kickSpeed;
    public float unkickedAngle;
    public float kickedAngle;
    //float doorRotation = 0;

    // Use this for initialization
    void Start ()
    {
        gameObject.tag = "Interact";
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Quaternion target;
        //if (LogKicked == true)
        //{
        //    target = Quaternion.Euler(0, 0, kickedAngle);
        //}
        //else
        //{
        //    target = Quaternion.Euler(0, 0, unkickedAngle);
        //}

        //transform.localRotation = Quaternion.Slerp(transform.localRotation, target, Time.deltaTime * kickSpeed);
    }

    public void Interact()
    {
        Debug.Log("Log.Interact Called");
        interactedObject.GetComponent<LogPivot>().Interact();
        GetKicked();
    }
    
    void GetKicked()
    {
        if (interactedObject.tag.Equals("LogPivot"))
        {
            interactedObject.GetComponent<LogPivot>().Interact();
        }
        //LogKicked = true;
    }
}
