using UnityEngine;
using System.Collections;

public class BearTrap : MonoBehaviour
{
    Animator anim;
    public GameObject Owl;
    public GameObject arrow;
    public GameObject trigger;

    bool arrowFlight = false;

    public float speed;
    public float turnSpeed;
    GameObject ArrowSpawn;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        transform.tag = "BearTrap";
    }

    // Update is called once per frame
    void Update()
    {
        flight();
    }
    void OnTriggerEnter()
    {
        //arrow.transform.parent = null;
        ArrowSpawn = (GameObject)Instantiate(arrow, Owl.transform.position, Quaternion.identity);
        ArrowSpawn.transform.rotation = Quaternion.Slerp(ArrowSpawn.transform.rotation, Quaternion.LookRotation(trigger.transform.position - ArrowSpawn.transform.position), turnSpeed * Time.deltaTime);
        arrowFlight = true;

        anim.Play("BearTrap");
    }
    void flight()
    {
        if (arrowFlight)
        {
            ArrowSpawn.transform.position = Vector3.Lerp(ArrowSpawn.transform.position, trigger.transform.position, speed * Time.deltaTime);
        }
    }
}

