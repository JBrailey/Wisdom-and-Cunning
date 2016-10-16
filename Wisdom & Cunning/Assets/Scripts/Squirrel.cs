using UnityEngine;
using System.Collections;

public class Squirrel : MonoBehaviour {

    public bool asleep;
    Animator anim;
    public bool startAwake;

	// Use this for initialization
	void Start ()
    {
        if (startAwake)
        {
            anim.Play("Awake");
        }else
        {
            anim.Play("Asleep");
        }
        anim.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (asleep == false)
        {
            GetComponent<BoxCollider>().enabled = false;
        }
        else
        {
            GetComponent<BoxCollider>().enabled = true;
        }
	}

    public void Interact(bool isWakingUp)
    {
        Debug.Log("Squirrel.Interact Called");
        if (isWakingUp)
        {
            if (!asleep)
            {
                FallAsleep();
            }
            else
            {
                WakeUp();
            }
        }
        else
        {
            FallAsleep();
        }
    }

    void WakeUp()
    {
        asleep = false;
        anim.Play("Wake Up");
    }

    void FallAsleep()
    {
        asleep = true;
        anim.Play("Fall Asleep");
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);
        if (asleep)
        {
            anim.Play("Asleep");
        }
        else
        {
            anim.Play("Awake");
        }
    }
}
