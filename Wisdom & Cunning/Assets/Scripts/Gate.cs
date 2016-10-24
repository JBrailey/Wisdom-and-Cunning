using UnityEngine;
using System.Collections;

public class Gate : MonoBehaviour
{
    // Gate Type
    public bool isLockedGate;
    public bool isKickedGate;
    public bool isLeverGate;

    // Door Variables
    public bool isOpen = false;
    public float doorSpeed = 1f;
    float closedAngle = 0;
    float openAngle = -90;

    // Keys
    public int keysRequired;
    int keyCount = 0;

    void Start()
    {
        gameObject.tag = "Gate";

        // To Make sure only one is active
        if (isKickedGate)
        {
            isLockedGate = false;
            isLeverGate = false;
        }
        else if (isLockedGate)
        {
            isKickedGate = false;
            isLeverGate = false;
        }
        else if (isLeverGate)
        {
            isLockedGate = false;
            isKickedGate = false;
        }
    }

    void Update()
    {
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
        Debug.Log("Gate Told to Interact");

        if (isKickedGate || isLeverGate)
        {
            isOpen = true;
            if (isLeverGate)
            {
                transform.GetChild(0).gameObject.SetActive(false);
            }
        }
        else if (isLockedGate)
        {
            if (isUnlocked())
            {
                transform.GetChild(0).gameObject.SetActive(false); // Get rid of Plane
                isOpen = true;
            }
        }
    }

    private bool isUnlocked()
    {
        if (keysRequired == keyCount)
        {
            return true;
        }
        return false;
    }

    public int UseKeys(int keysUsed)
    {
        if (keysUsed >= keysRequired)
        {
            while (keyCount < keysRequired && keysUsed > 0)
            {
                keyCount++;
                keysUsed--;
            }
        }
        return keysUsed;
    }
}
