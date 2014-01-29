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

    void OnTriggerEnter2D(Collider2D collider)
    {
        // is it a shot?
        ShotScript shot = collider.gameObject.GetComponent<ShotScript>();
        HealthScript health = collider.gameObject.GetComponent<HealthScript>();
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
