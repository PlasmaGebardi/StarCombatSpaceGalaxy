using UnityEngine;
using System.Collections;

/// Handle hitpoints and damages
public class HealthScript : MonoBehaviour
{
	/// Total hitpoints
	public int hp = 2;
	
	/// Enemy or player?
	public bool isEnemy = true;
	
	void OnTriggerEnter2D(Collider2D collider)
	{
		// Is this a shot?
		ShotScript shot = collider.gameObject.GetComponent<ShotScript>();
		if (shot != null)
		{
			// Avoid friendly fire
			if (shot.isEnemyShot != isEnemy)
			{
				hp -= shot.damage;
				
				// Destroy the shot
				// Remember to always target the game object,
				// otherwise you will just remove the script.
				Destroy(shot.gameObject);
				
				if (hp <= 0)
				{
					// Dead!
					Destroy(gameObject);
				}
			}
		}
	}
}