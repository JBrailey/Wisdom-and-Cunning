﻿using UnityEngine;
using System.Collections;

public class AxePicker : MonoBehaviour
{

    public GameObject axe1, axe2, axe3, axe4;
    bool Axe1Set = false, Axe2Set = false, Axe3Set = false, Axe4Set = false;

    // Use this for initialization
    void Start()
    {
        axe1.GetComponent<Axe>().manager = gameObject;
        axe2.GetComponent<Axe>().manager = gameObject;
        axe3.GetComponent<Axe>().manager = gameObject;
        axe4.GetComponent<Axe>().manager = gameObject;
        DetermineAxes();
    }

    void DetermineAxes()
    {
        int axeNum = Random.Range(0, 4);
        bool axeSet = false;

        SetAxe(axeNum, 'A'); // Axe A
        axeNum = Random.Range(0, 4);

        while (!axeSet) // Axe B
        {
            if (!CheckIfSet(axeNum))
            {
                SetAxe(axeNum, 'B');
                axeSet = true;
            }
            axeNum = Random.Range(0, 4);
        }

        axeSet = false;
        while (!axeSet) // Axe C
        {
            if (!CheckIfSet(axeNum))
            {
                SetAxe(axeNum, 'C');
                axeSet = true;
            }
            axeNum = Random.Range(0, 4);
        }

        axeSet = false;
        while (!axeSet) // Axe D
        {
            if (!CheckIfSet(axeNum))
            {
                SetAxe(axeNum, 'D');
                axeSet = true;
            }
            axeNum = Random.Range(0, 4);
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
            Axe1Set = true;
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
            Axe2Set = true;
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
            Axe3Set = true;
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
            Axe4Set = true;
        }
    }

    public void DeactivateAxes()
    {
        axe1.GetComponent<Axe>().canInteract = false;
        axe2.GetComponent<Axe>().canInteract = false;
        axe3.GetComponent<Axe>().canInteract = false;
        axe4.GetComponent<Axe>().canInteract = false;
    }
}
