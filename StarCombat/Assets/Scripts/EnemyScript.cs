using UnityEngine;

/// <summary>
/// Enemy generic behavior
/// </summary>
public class EnemyScript : MonoBehaviour
{
	private bool hasSpawn;
	private EnemyMove moveScript;
	private WeaponScript[] weapons;
    private BossScript bossScript;

    public bool limitYaxis = false;
	void Awake()
	{
		// Retrieve the weapon only once
		weapons = GetComponentsInChildren<WeaponScript>();
		
		// Retrieve scripts to disable when not spawn
		moveScript = GetComponent<EnemyMove>();

        if (GetComponent<BossScript>())
        {
            bossScript = GetComponent<BossScript>();
        }
	}
	
	// 1 - Disable everything
	void Start()
	{
		hasSpawn = false;
		
		// Disable everything
		// -- collider
		collider2D.enabled = false;
		// -- Moving
		moveScript.enabled = false;
		// -- Shooting
        if (bossScript)
        {
            bossScript.enabled = false;
        }
		foreach (WeaponScript weapon in weapons)
		{
			weapon.enabled = false;
		}
	}
	
	void Update()
	{
		// 2 - Check if the enemy has spawned.
		if (hasSpawn == false)
		{
			if (renderer.IsVisibleFrom(Camera.main))
			{
				Spawn();
			}
		}
		else
		{
			// Auto-fire
			foreach (WeaponScript weapon in weapons)
			{
				if (weapon != null && weapon.enabled && weapon.CanAttack)
				{
					weapon.Attack(true);
					SoundEffectsHelper.Instance.MakeEnemyShotSound();
				}
			}
			
			// 4 - Out of the camera ? Destroy the game object.
			if (renderer.IsVisibleFrom(Camera.main) == false)
			{
				Destroy(gameObject);
			}
		}

        if (limitYaxis == true)
        {
            var dist = (transform.position - Camera.main.transform.position).z;

            var leftBorder = Camera.main.ViewportToWorldPoint(
                new Vector3(0, 0, dist)
                ).x;

            var rightBorder = Camera.main.ViewportToWorldPoint(
                new Vector3(1, 0, dist)
                ).x;

            var topBorder = Camera.main.ViewportToWorldPoint(
                new Vector3(0, 0, dist)
                ).y;

            var bottomBorder = Camera.main.ViewportToWorldPoint(
                new Vector3(0, 1, dist)
                ).y;

            transform.position = new Vector3(
                transform.position.x,
                Mathf.Clamp(transform.position.y, topBorder, bottomBorder),
                transform.position.z
                );
        }
	}
	
	// 3 - Activate itself.
	private void Spawn()
	{
		hasSpawn = true;
		
		// Enable everything
		// -- Collider
		collider2D.enabled = true;
		// -- Moving
		moveScript.enabled = true;
		// -- Shooting

        if (bossScript)
        {
            bossScript.enabled = true;
        }
		foreach (WeaponScript weapon in weapons)
		{
			weapon.enabled = true;
		}
	}
}
