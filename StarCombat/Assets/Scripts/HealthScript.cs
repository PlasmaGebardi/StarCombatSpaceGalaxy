using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {

    // Total HP
    public int maxhp = 2;
    public int hp = 2;

    // Friend or foe, default for enemy
    public bool isEnemy = true;

    // is it an asteroid
    public bool isAsteroid = false;

    // is it an asteroid split
    public bool isSplit = false;

    // damage inflicted on collision
    public int collDam = 1;

    public Transform dropObject;

    //Store weaponscripts
    private WeaponScript weaponscript;
    private Asteroidittaja asteroidittaja;
    private BossScript bossScript;
    private PlayerScript playerScript;
    void OnTriggerEnter2D(Collider2D collider)
    {
        // is it a shot?
        ShotScript shot = collider.gameObject.GetComponent<ShotScript>();
        HealthScript health = collider.gameObject.GetComponent<HealthScript>();
        weaponscript = GetComponentInChildren<WeaponScript>();
        asteroidittaja = GetComponent<Asteroidittaja>();
        Vector2 pos = transform.position;
        if(GetComponent<BossScript>())
        {
            bossScript = GetComponent<BossScript>();
        }

        if (GetComponent<PlayerScript>())
        {
            playerScript = GetComponent<PlayerScript>();
        }

        if (shot != null)
        {
            // no friendly fire
            if (shot.isEnemyShot != isEnemy)
            {
                hp -= shot.damage;
                // upon collision, the shot is destroyed
                if (playerScript)
                {
                    playerScript.Fade();
                }
                Destroy(shot.gameObject);

                if (hp <= 0)
				{
                    if (isAsteroid == true && isSplit == false)
                    {
                        var weapon = transform.FindChild("WeaponObject");
                        int splits = asteroidittaja.getSplits();
                        for (int i = 0; i < splits; i++)
                        {

                            int rndm = Random.Range(1, 360);
                            weapon.transform.Rotate(0, 0, rndm);
                            weaponscript.Attack(true);
                        }

                    }
                    if (!bossScript)
                    {
                            SpecialEffectsHelper.Instance.Explosion(transform.position);
                            SoundEffectsHelper.Instance.MakeExplosionSound();
                            if (dropObject)
                            {
                                GameObject objt = Instantiate(dropObject) as GameObject;
                                objt.transform.position = pos;
                            }
                            Destroy(gameObject);
                    }
                    else
                    {
                        bossScript.OnDeath();
                    }
                }
            }
        }
        else if (health != null)
        {
            // no friendly fire
            if (health.isEnemy != isEnemy | isAsteroid)
            {
                hp -= health.collDam;
                if (playerScript)
                {
                    playerScript.Fade();
                }
                // upon collision, check if collible object
				if (!health.isEnemy) {
                    if (!bossScript)
                    {
                            SpecialEffectsHelper.Instance.Explosion(transform.position);
                            SoundEffectsHelper.Instance.MakeExplosionSound();
                                if (dropObject)
                                {
                                    var dropTransform = Instantiate(dropObject) as Transform;
                                    dropTransform.position = transform.position;
                                }
                            Destroy(gameObject);

                    }
                    else
                    {
                        bossScript.OnDeath();
                    };
                }

                // destroy player if health reaches zero
                if (hp <= 0) { 
					SpecialEffectsHelper.Instance.Explosion(transform.position);
					SoundEffectsHelper.Instance.MakeExplosionSound();
					Destroy(gameObject); }
            }
        }
    }

}
