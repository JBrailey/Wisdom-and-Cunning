using UnityEngine;
using System.Collections;

public class BearTrap : MonoBehaviour
{
    Animator anim;
    public GameObject Owl;
    public GameObject arrow;
    public GameObject trigger;
    public GameObject followpoint;

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
        if (arrow.activeSelf == true)
        {
            ArrowSpawn = (GameObject)Instantiate(arrow, Owl.transform.position, Quaternion.identity);
            ArrowSpawn.transform.LookAt(trigger.transform);
            arrowFlight = true;
            arrow.SetActive(false);
            anim.Play("BearTrap");
            followpoint.SetActive(false);

        }
    }
    void flight()
    {
        if (arrowFlight)
        {
            ArrowSpawn.transform.position = Vector3.Lerp(ArrowSpawn.transform.position, trigger.transform.position, speed * Time.deltaTime);
        }
    }
}

