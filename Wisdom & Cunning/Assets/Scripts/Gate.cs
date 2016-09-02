using UnityEngine;
using System.Collections;

public class Gate : MonoBehaviour {

    public bool isOpen = false;
    public float doorSpeed = 1f;

    float closedAngle = 90;
    float openAngle = 0;    
    float doorRotation = 0;

	// Update is called once per frame
	void Update () {
        Quaternion target;
        if (isOpen)
        {
            target = Quaternion.Euler(0, openAngle, 0);           
        }
        else
        {
            target = Quaternion.Euler(0, closedAngle, 0);
        }
        transform.localRotation = Quaternion.Slerp(transform.localRotation, target,
        Time.deltaTime * doorSpeed);
    }

    public void Interact()
    {
        isOpen = true;
    }
}
