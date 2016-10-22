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
    public GameObject manager;

    public bool canInteract = true;

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

    void CheckIfSolved()
    {
        if (!squirrels[0].GetComponent<Squirrel>().asleep)
        {
            if (!squirrels[1].GetComponent<Squirrel>().asleep)
            {
                if (!squirrels[2].GetComponent<Squirrel>().asleep)
                {
                    if (!squirrels[3].GetComponent<Squirrel>().asleep)
                    {
                        squirrels[0].GetComponent<Squirrel>().RunAway();
                        squirrels[1].GetComponent<Squirrel>().RunAway();
                        squirrels[2].GetComponent<Squirrel>().RunAway();
                        squirrels[3].GetComponent<Squirrel>().RunAway();
                        manager.GetComponent<AxePicker>().DeactivateAxes();
                    }
                }
            }
        }
    }

    public void Interact()
    {
        Debug.Log("Axe.Interact Called");
        if (canInteract)
        {
            foreach (GameObject squirrel in SquirrelToWake)
            {
                squirrel.GetComponent<Squirrel>().Interact(true);
            }

            foreach (GameObject squirrel in SquirrelToSleep)
            {
                squirrel.GetComponent<Squirrel>().Interact(false);
            }
            CheckIfSolved();
        }
    }
}
