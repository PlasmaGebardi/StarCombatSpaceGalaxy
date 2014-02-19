using UnityEngine;
using System.Collections;
using System.Timers;

public class PlayerScript : MonoBehaviour
{
	/// 1 - The speed of the ship
	public Vector2 speed = new Vector2(50, 50);
	// 2 - Store the movement
	private Vector2 movement;
    public bool disableHealthBar;
    private HealthScript hpscript;
    private GameObject obje;
    private System.Timers.Timer timer;
    private bool helper = false;

    void Start()
    {
        hpscript = GetComponent<HealthScript>();
        obje = GameObject.Find("ScreenFlash");
    }
	void Update()
	{
		// 3 - Retrieve axis information
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");
		
		// 4 - Movement per direction
		movement = new Vector2(
			speed.x * inputX,
			speed.y * inputY);

		// 5 - Shooting
		bool shoot = Input.GetButtonDown("Fire1");
		shoot |= Input.GetButtonDown("Fire2");
		// Careful: For Mac users, ctrl + arrow is a bad idea
		
		if (shoot)
		{
			WeaponScript weapon = GetComponent<WeaponScript>();
			if (weapon != null)
			{
				// false because the player is not an enemy
				weapon.Attack(false);
			}
			SoundEffectsHelper.Instance.MakePlayerShotSound();
		}

		// 6 - Make sure we are not outside the camera bounds
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
			Mathf.Clamp(transform.position.x, leftBorder, rightBorder),
			Mathf.Clamp(transform.position.y, topBorder, bottomBorder),
			transform.position.z
			);

        if (helper == true)
        {
            obje.guiTexture.enabled = false;
            helper = false;
        }

	}
	
	void FixedUpdate()
	{
		// 5 - Move the game object
		rigidbody2D.velocity = movement;
	}


    public void OnGUI()
    {

        Texture2D back = new Texture2D(1,1);
        back.SetPixel(0, 0, Color.red);
        back.Apply();
        GUI.backgroundColor = Color.red;
        if (disableHealthBar == false)
        {
            GUI.Box(new Rect(10, 10, 150, 30), hpscript.hp + "/" + hpscript.maxhp);
        }
        GUI.skin.box.normal.background = back;
        GUI.skin.box.fontSize = 15;

    }

    public void Fade()
    {
        obje.guiTexture.enabled = true;
        timer = new System.Timers.Timer(10);
        timer.Elapsed += new ElapsedEventHandler(FlashHelp);
        timer.Enabled = true;

    }
    void FlashHelp(object source, ElapsedEventArgs e)
    {
        helper = true;
        timer.Enabled = false;
    }
    void OnDestroy()
    {
        obje.guiTexture.enabled = false;
    }

}