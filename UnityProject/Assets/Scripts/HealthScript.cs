using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {

    // Total HP
    public int hp = 2;

    // Friend or foe, default for enemy
    public bool isEnemy = true;

    void OnTriggerEnter2D(Collider2D collider)
    {
        // is it a shot?
        ShotScript shot = collider.gameObject.GetComponent<ShotScript>();
        if (shot != null)
        {
            // no friendly fire
            if (shot.isEnemyShot != isEnemy)
            {
                hp -= shot.damage;

                // upon collision, the shot is destroyed
                Destroy(shot.gameObject);

                if (hp <= 0) { Destroy(gameObject); }
            }
        }
    }

}
