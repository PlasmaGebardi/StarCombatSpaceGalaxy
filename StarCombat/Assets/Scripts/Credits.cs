using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour {

    void OnGUI()
    {
        GUIStyle ControlsStyle = new GUIStyle();
        ControlsStyle.fontSize = 23;
        ControlsStyle.normal.textColor = Color.white;

        GUI.Label(new Rect(Screen.width / 4, Screen.height + (Time.timeSinceLevelLoad * -50), Screen.width / 2, 1000), "Marlo Ekberg: Project Manager / Assisting Code Master", ControlsStyle);
        GUI.Label(new Rect(Screen.width / 4, Screen.height + 100 + (Time.timeSinceLevelLoad * -50), Screen.width / 2, 1000), "Matti Määttänen: Code Master", ControlsStyle);
        GUI.Label(new Rect(Screen.width / 4, Screen.height + 200 + (Time.timeSinceLevelLoad * -50), Screen.width / 2, 1000), "Mikko Forsman: Code Master", ControlsStyle);
        GUI.Label(new Rect(Screen.width / 4, Screen.height + 300 + (Time.timeSinceLevelLoad * -50), Screen.width / 2, 1000), "Topi Salonen: Graphic Sensei", ControlsStyle);
        GUI.Label(new Rect(Screen.width / 4, Screen.height + 400 + (Time.timeSinceLevelLoad * -50), Screen.width / 2, 1000), "Jesse Grönlund: The Mozart", ControlsStyle);
        //GUI.skin.label.wordWrap = true;

        const int buttonWidth = 130;
        const int buttonHeight = 75;

        if (GUI.Button(
        new Rect(Screen.width - 180, (Screen.height - 120), buttonWidth, buttonHeight), "Back"))
        {   // launch the first (currently only level)
            Application.LoadLevel("Menu");
        }
        
    }
}
