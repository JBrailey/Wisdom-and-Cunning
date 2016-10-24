using UnityEngine;
using System.Collections;

public class Crossbow : MonoBehaviour {

    public Transform target; // Projectile Target
    public GameObject projectileObject;
    public Transform projectileSpawn;
    public GameObject arrow;

    public float projectileSpeed = 15f;

    AudioSource arrowFX;

	// Use this for initialization
	void Start () {
        arrowFX = GetComponent<AudioSource>();
        transform.LookAt(target);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Interact()
    {
        Shoot();
    }

    void Shoot()
    {
        if (arrow.activeSelf == true)
        {
            arrowFX.Play();
            GameObject projectile = (GameObject)Instantiate(projectileObject, projectileSpawn.position, Quaternion.identity);
            projectile.GetComponent<Projectile>().Setup(target, projectileSpeed);
            arrow.SetActive(false);
        }
    }
}