using UnityEngine;
using System.Collections;

public class LogPivot : MonoBehaviour
{

    public GameObject interactedObject;
    Vector3 vectorKicked = new Vector3(5, -1, 0);

    bool LogKicked = false;

    public float kickSpeed;
    public float unkickedAngle;
    public float kickedAngle;
    //float doorRotation = 0;

    // Use this for initialization
    void Start()
    {
        gameObject.tag = "LogPivot";
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion target;
        if (LogKicked == true)
        {
            target = Quaternion.Euler(0, 0, kickedAngle);
        }
        else
        {
            target = Quaternion.Euler(0, 0, unkickedAngle);
        }

        transform.localRotation = Quaternion.Slerp(transform.localRotation, target, Time.deltaTime * kickSpeed);
    }

    public void Interact()
    {
        Debug.Log("LogPivot.Interact Called");
        GetKicked();
    }

    void GetKicked()
    {
        LogKicked = true;
    }
}
