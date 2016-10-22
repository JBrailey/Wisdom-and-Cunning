using UnityEngine;
using System.Collections;

public class AxePicker : MonoBehaviour
{

    public GameObject axe1, axe2, axe3, axe4;
    bool Axe1Set = false, Axe2Set = false, Axe3Set = false, Axe4Set = false;

    // Use this for initialization
    void Start()
    {
        DetermineAxes();
    }

    void DetermineAxes()
    {
        int axeNum = Random.Range(0, 3);

        SetAxe(axeNum, 'A'); // Axe A

        while (!CheckIfSet(axeNum)) // Axe B
        {
            if (!CheckIfSet(axeNum))
            {
                SetAxe(axeNum, 'B');
            }
            axeNum = Random.Range(0, 3);
        }
        while (!CheckIfSet(axeNum)) // Axe C
        {
            if (!CheckIfSet(axeNum))
            {
                SetAxe(axeNum, 'C');
            }
            axeNum = Random.Range(0, 3);
        }
        while (!CheckIfSet(axeNum)) // Axe D
        {
            if (!CheckIfSet(axeNum))
            {
                SetAxe(axeNum, 'D');
            }
            axeNum = Random.Range(0, 3);
        }
    }

    bool CheckIfSet(int num)
    {
        if (num == 0)
        {
            if (Axe1Set)
            {
                return true;
            }
        }
        else if (num == 1)
        {
            if (Axe2Set)
            {
                return true;
            }
        }
        else if (num == 2)
        {
            if (Axe3Set)
            {
                return true;
            }
        }
        else if (num == 3)
        {
            if (Axe4Set)
            {
                return true;
            }
        }
        return false;
    }

    void SetAxe(int axeNum, char axeLetter)
    {
        if (axeNum == 0)
        {
            if (axeLetter == 'A')
            {
                axe1.GetComponent<Axe>().axes.isAxeA = true;
            }
            else if (axeLetter == 'B')
            {
                axe1.GetComponent<Axe>().axes.isAxeB = true;
            }
            else if (axeLetter == 'C')
            {
                axe1.GetComponent<Axe>().axes.isAxeC = true;
            }
            else if (axeLetter == 'D')
            {
                axe1.GetComponent<Axe>().axes.isAxeD = true;
            }
        }
        else if (axeNum == 1)
        {
            if (axeLetter == 'A')
            {
                axe2.GetComponent<Axe>().axes.isAxeA = true;
            }
            else if (axeLetter == 'B')
            {
                axe2.GetComponent<Axe>().axes.isAxeB = true;
            }
            else if (axeLetter == 'C')
            {
                axe2.GetComponent<Axe>().axes.isAxeC = true;
            }
            else if (axeLetter == 'D')
            {
                axe2.GetComponent<Axe>().axes.isAxeD = true;
            }
        }
        else if (axeNum == 2)
        {
            if (axeLetter == 'A')
            {
                axe3.GetComponent<Axe>().axes.isAxeA = true;
            }
            else if (axeLetter == 'B')
            {
                axe3.GetComponent<Axe>().axes.isAxeB = true;
            }
            else if (axeLetter == 'C')
            {
                axe3.GetComponent<Axe>().axes.isAxeC = true;
            }
            else if (axeLetter == 'D')
            {
                axe3.GetComponent<Axe>().axes.isAxeD = true;
            }
        }
        else if (axeNum == 3)
        {
            if (axeLetter == 'A')
            {
                axe4.GetComponent<Axe>().axes.isAxeA = true;
            }
            else if (axeLetter == 'B')
            {
                axe4.GetComponent<Axe>().axes.isAxeB = true;
            }
            else if (axeLetter == 'C')
            {
                axe4.GetComponent<Axe>().axes.isAxeC = true;
            }
            else if (axeLetter == 'D')
            {
                axe4.GetComponent<Axe>().axes.isAxeD = true;
            }
        }
    }
}
