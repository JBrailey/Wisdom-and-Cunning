using UnityEngine;
using System.Collections;

[System.Serializable]
public class Axes : System.Object
{
    public bool isAxeA;
    public bool isAxeB;
    public bool isAxeC;
    public bool isAxeD;
}

public class Axe : MonoBehaviour {

    public GameObject[] squirrels = new GameObject[4];
    public Axes axes;

    GameObject[] SquirrelToSleep, SquirrelToWake;

    // Use this for initialization
    void Start()
    {
        gameObject.tag = "Axe";

        if (axes.isAxeA) // 3 Wakes, 4 Sleeps
        {
            SquirrelToWake[0] = squirrels[2];
            SquirrelToSleep[0] = squirrels[3];
        }
        else if (axes.isAxeB) // 1 Wakes, 3 Sleeps
        {
            SquirrelToWake[0] = squirrels[0];
            SquirrelToSleep[0] = squirrels[2];
        }
        else if (axes.isAxeC) // 3 Wakes, 1 & 2 Sleep
        {
            SquirrelToWake[0] = squirrels[2];
            SquirrelToSleep[0] = squirrels[0];
            SquirrelToSleep[1] = squirrels[1];
        }
        else if (axes.isAxeD) // 2 & 4 Wake
        {
            SquirrelToWake[0] = squirrels[1];
            SquirrelToWake[1] = squirrels[3];
        }
    }

    // Update is called once per frame
    void Update () {
	
	}

    public void Interact()
    {
        Debug.Log("Axe.Interact Called");

       foreach(GameObject squirrel in SquirrelToWake)
        {
            squirrel.GetComponent<Squirrel>().Interact(true);
        }

       foreach (GameObject squirrel in SquirrelToSleep)
        {
            squirrel.GetComponent<Squirrel>().Interact(false);
        }
    }
}
