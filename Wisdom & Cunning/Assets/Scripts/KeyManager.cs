using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KeyManager : MonoBehaviour {

    public Transform keyGUI;

    int keyCount = 0;
    Text text;
    
    // Use this for initialization
	void Start () {
        text = keyGUI.GetComponent<Text>();
	}

    public void PickUpKey(int keyAmount)
    {
        keyCount += keyAmount;
        UpdateKeyVisual();
    }

    public void UseKeys(GameObject gate)
    {
        keyCount = gate.GetComponent<Gate>().UseKeys(keyCount);
        UpdateKeyVisual();
    }

    void UpdateKeyVisual()
    {
        text.text = "" + keyCount;
    }
}
