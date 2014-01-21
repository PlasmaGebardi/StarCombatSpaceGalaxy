using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour {

    // Tweaking variables
    // Projectile prefab
    public Transform shotPrefab;

    // cooldown in seconds
    public float shootingRate = 0.25f;

    // Cooldown implementation
    private float shootCooldown;

	void Start () {
        shootCooldown = 0f;
	}
	
	// Update is called once per frame
	void Update () {
        if (shootCooldown > 0) { shootCooldown -= Time.deltaTime; }
	}

    public void Attack(bool isEnemy)
    {
        if (CanAttack)
        {
            shootCooldown = shootingRate;

            // new shot
            var shotTransform = Instantiate(shotPrefab) as Transform;

            // create shot in the same place as the shooter
            shotTransform.position = transform.position;

            // determine if the shooter is enemy or not
            ShotScript shot = 
                shotTransform.gameObject.GetComponent<ShotScript>();
            if (shot != null) { shot.isEnemyShot = isEnemy; }

            // make weapon shoot left if enemy, else in the 
            // direction of the ship movement(NOT YET)
            MoveScript move =
                shotTransform.gameObject.GetComponent<MoveScript>();
            if (move != null) { move.direction = this.transform.right; }
            
            
        }
    }
    public bool CanAttack { get { return shootCooldown <= 0f; } }
}
