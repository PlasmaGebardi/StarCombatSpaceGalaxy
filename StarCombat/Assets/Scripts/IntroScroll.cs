using UnityEngine;
using System.Collections;

public class IntroScroll : MonoBehaviour {

    private float timer = 23f;
	// Use this for initialization
	void Start () {
	
	}
    void Update()
    {

        timer -= Time.deltaTime;
        if (timer < 0)
        {
            Application.LoadLevel("StarCombat");
        }

    }

    void OnGUI()
    {
        GUI.Label(new Rect(Screen.width / 4, Screen.height + (Time.time * -50), Screen.width/2, 1000), "In a universe reasonably far away... ");
        GUI.Label(new Rect(Screen.width / 4, Screen.height + 100 + (Time.time * -50), Screen.width , 1000), "There are space enemies, space asteroids and space planets. ");
        GUI.Label(new Rect(Screen.width / 4, Screen.height + 200 + (Time.time * -50), Screen.width / 2, 1000), "No worries, we has weapons! And a space ship!");
        GUI.Label(new Rect(Screen.width / 4, Screen.height + 300 + (Time.time * -50), Screen.width / 2, 1000), "On our epic journey to save the space princess,");
        GUI.Label(new Rect(Screen.width / 4, Screen.height + 400 + (Time.time * -50), Screen.width / 2, 1000), "our hero will encounter many space obstacles");
        GUI.Label(new Rect(Screen.width / 4, Screen.height + 500 + (Time.time * -50), Screen.width / 2, 1000), "to overcome and conquer the space world.");
        GUI.skin.label.fontSize = 30;
        GUI.skin.label.wordWrap = true;

        GUIStyle ControlsStyle = new GUIStyle();
        ControlsStyle.fontSize = 18;
        ControlsStyle.normal.textColor = Color.magenta;
        GUI.Box(new Rect(10, Screen.height - 80, 150, 30), "WASD to move", ControlsStyle);
        GUI.Box(new Rect(10, Screen.height - 60, 150, 30), "Mouse1 or ctrl to shoot", ControlsStyle);

        const int buttonWidth = 130;
        const int buttonHeight = 75;

        GUI.skin.button.fontSize = 20;
        if (GUI.Button(
            new Rect(Screen.width - 180,(Screen.height - 120),buttonWidth,buttonHeight),"Skip intro"))
        {   // launch the first (currently only level)
            Application.LoadLevel("StarCombat");
        }
    }
}
