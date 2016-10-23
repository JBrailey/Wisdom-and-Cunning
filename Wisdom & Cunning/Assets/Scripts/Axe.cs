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

public class Axe : MonoBehaviour
{

    public GameObject[] squirrels = new GameObject[4];
    public Axes axes;
    public GameObject manager;

    public bool canInteract = true;

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
            if (axes.isAxeA) // 3 Wakes, 4 Sleeps
            {
                squirrels[2].GetComponent<Squirrel>().Interact(true);
                squirrels[3].GetComponent<Squirrel>().Interact(false);
                canInteract = false;
                StartCoroutine(Wait());
            }
            else if (axes.isAxeB) // 1 Wakes, 3 Sleeps
            {
                squirrels[0].GetComponent<Squirrel>().Interact(true);
                squirrels[2].GetComponent<Squirrel>().Interact(false);
                canInteract = false;
                StartCoroutine(Wait());
            }
            else if (axes.isAxeC) // 3 Wakes, 1 & 2 Sleep
            {
                squirrels[2].GetComponent<Squirrel>().Interact(true);
                squirrels[0].GetComponent<Squirrel>().Interact(false);
                squirrels[1].GetComponent<Squirrel>().Interact(false);
                canInteract = false;
                StartCoroutine(Wait());
            }
            else if (axes.isAxeD) // 2 & 4 Wake
            {
                squirrels[1].GetComponent<Squirrel>().Interact(true);
                squirrels[3].GetComponent<Squirrel>().Interact(true);
                canInteract = false;
                StartCoroutine(Wait());
            }
        }
        CheckIfSolved();
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);
        canInteract = true;
    }
}

