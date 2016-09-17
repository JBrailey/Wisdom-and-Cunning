using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    public float speed = 15f;
    public Transform target;
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(10f); //DeActivates projectile if it hits nothing for 10 seconds
        Debug.Log("I died after 10 seconds");
        gameObject.SetActive(false);
    }

    public void Setup(Transform target, float speed)
    {
        this.target = target;
        this.speed = speed;
        transform.LookAt(target);
        gameObject.tag = "Projectile";
    }

    void OnCollisionEnter(Collision collision)
    {
        gameObject.SetActive(false);
    }
}
