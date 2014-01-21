using UnityEngine;
using System.Collections;

public class ShotScript : MonoBehaviour {

    // Damage of shot
    public int damage = 1;

    // Projectile damage enemy?
    public bool isEnemyShot = false;

	// Use this for initialization
	void Start () {
        // ttl for the bullet in seconds
        Destroy(gameObject, 5);
	}
	
	// Update is called once per frame
	//void Update () {
	
	//}
}
