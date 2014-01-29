using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {

    // Total HP
    public int hp = 2;

    // Friend or foe, default for enemy
    public bool isEnemy = true;

    // is it an asteroid
    public bool isAsteroid = false;

    // damage inflicted on collision
    public int collDam = 1;

    //Store weaponscripts
    private WeaponScript weaponscript;
    private Asteroidittaja asteroidittaja;

    void OnTriggerEnter2D(Collider2D collider)
    {
        // is it a shot?
        ShotScript shot = collider.gameObject.GetComponent<ShotScript>();
        HealthScript health = collider.gameObject.GetComponent<HealthScript>();
        weaponscript = GetComponentInChildren<WeaponScript>();
        asteroidittaja = GetComponent<Asteroidittaja>();

        if (shot != null)
        {
            // no friendly fire
            if (shot.isEnemyShot != isEnemy)
            {
                hp -= shot.damage;

                // upon collision, the shot is destroyed
                Destroy(shot.gameObject);

                if (hp <= 0)
				{
                    if (isAsteroid == true)
                    {
                        var weapon = transform.FindChild("WeaponObject");
                        int splits = asteroidittaja.getSplits();
                        for (int i = 0; i < splits; i++)
                        {

                            int rndm = Random.Range(1, 360);
                            weapon.transform.Rotate(0, 0, rndm);
                            weaponscript.Attack(true);
                            print("asd");
                        }

                    }
					SpecialEffectsHelper.Instance.Explosion(transform.position);
					Destroy(gameObject); }
            }
        }
        else if (health != null)
        {
            // no friendly fire
            if (health.isEnemy != isEnemy)
            {
                hp -= health.collDam;

                // upon collision, check if collible object
                if (health.isEnemy) { Destroy(health.gameObject); }

                // destroy player if health reaches zero
                if (hp <= 0) { 
					SpecialEffectsHelper.Instance.Explosion(transform.position);
					Destroy(gameObject); }
            }
        }
    }

}
