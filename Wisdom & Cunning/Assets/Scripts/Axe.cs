using UnityEngine;
using System.Collections;

public class Axe : MonoBehaviour {

    public GameObject SquirrelToWake;
    public GameObject SquirrelToWake2;
    public GameObject SquirrelToSleep;
    public GameObject SquirrelToSleep2;

    // Use this for initialization
    void Start()
    {
        gameObject.tag = "Axe";
    }

    // Update is called once per frame
    void Update () {
	
	}

    public void Interact()
    {
        Debug.Log("Axe.Interact Called");
        if (SquirrelToWake != null)
        {
            SquirrelToWake.GetComponent<Squirrel>().Interact(1);
        }
        if (SquirrelToWake2 != null)
        {
            SquirrelToWake2.GetComponent<Squirrel>().Interact(1);
        }
        if (SquirrelToSleep != null)
        {
            SquirrelToSleep.GetComponent<Squirrel>().Interact(2);
        }
        if (SquirrelToSleep2 != null)
        {
            SquirrelToSleep2.GetComponent<Squirrel>().Interact(2);
        }
    }
}
