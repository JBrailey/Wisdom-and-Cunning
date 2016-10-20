using UnityEngine;
using System.Collections;

public class SwitchPanels : MonoBehaviour {

    public GameObject turnOff, turnOn;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Fox")
        {
            turnOff.SetActive(false);
            turnOn.SetActive(true);
        }
    }
}
