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
        gameObject.tag = "Log";
    }
	
	// Update is called once per frame
	void Update ()
    {
        Quaternion target;
        if (LogKicked == true)
        {
            target = Quaternion.Euler(kickedAngle, 90, 0);
        }
        else
        {
           target = Quaternion.Euler(unkickedAngle, 90, 0);
        }

        transform.localRotation = Quaternion.Slerp(transform.localRotation, target, Time.deltaTime * kickSpeed);
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
