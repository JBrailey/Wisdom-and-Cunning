using UnityEngine;
using System.Collections;

public class Squirrel : MonoBehaviour {

    public bool asleep;
    Animator anim;
    public bool startAwake;
    public float speed = 10f;
    bool isMoving = false;

    AudioSource squirrelFX;

	// Use this for initialization
	void Start ()
    {
        squirrelFX = GetComponent<AudioSource>();
        anim = gameObject.GetComponent<Animator>();
        if (startAwake)
        {
            anim.Play("Awake");
        }else
        {
            anim.Play("Asleep");
        }       
	}
	
	// Update is called once per frame
	void Update () {
        if (isMoving)
        {
            transform.Translate(new Vector3(speed, 0, 0) * Time.deltaTime);
            anim.Play("Run");
        }
	}

    public void Interact(bool isWakingUp)
    {
        Debug.Log("Squirrel.Interact Called");
        if (isWakingUp)
        {
            WakeUp();
        }
        else
        {
            FallAsleep();
        }
    }

    void WakeUp()
    {
        squirrelFX.Play();
        asleep = false;
        anim.Play("Wake Up");
        StartCoroutine(Wait("WaitForIdle"));
    }

    void FallAsleep()
    {
        asleep = true;
        anim.Play("Fall Asleep");
        StartCoroutine(Wait("WaitForIdle"));
    }

    IEnumerator Wait(string action)
    {
        if (action.Equals("WaitForIdle"))
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
        else if (action.Equals("Despawn"))
        {
            yield return new WaitForSeconds(10f);
            gameObject.SetActive(false);
        }
    }

    public void RunAway()
    {
        transform.eulerAngles = new Vector3(0, -90, 0);
        isMoving = true;
        StartCoroutine(Wait("Despawn"));
    }
}
