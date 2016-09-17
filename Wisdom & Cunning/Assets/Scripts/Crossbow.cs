using UnityEngine;
using System.Collections;

public class Crossbow : MonoBehaviour {

    public Transform target; // Projectile Target
    public GameObject projectileObject;
    public Transform projectileSpawn;

    public float projectileSpeed = 15f;


	// Use this for initialization
	void Start () {
	    
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
        GameObject projectile = (GameObject)Instantiate(projectileObject, projectileSpawn.position, Quaternion.identity);
        projectile.GetComponent<Projectile>().Setup(target, projectileSpeed);        
    }
}