using UnityEngine;
using System.Collections;

public class OutroScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    void OnGUI()
    {
            GUI.Label(new Rect(Screen.width / 4, Screen.height + (Time.timeSinceLevelLoad * -50), Screen.width / 2, 1000), "There were space enemies, space asteroids and space planets");
            GUI.Label(new Rect(Screen.width / 4, Screen.height + 100 + (Time.timeSinceLevelLoad * -50), Screen.width / 2, 1000), "but the space princess seems to be in another dimension :(");
            GUI.Label(new Rect(Screen.width / 4, Screen.height + 300 + (Time.timeSinceLevelLoad * -50), Screen.width / 2, 1000), "Pay $6.09 to try another dimenson.");
            //GUI.skin.label.wordWrap = true;

            GUIStyle ControlsStyle = new GUIStyle();
            ControlsStyle.fontSize = 18;
            ControlsStyle.normal.textColor = Color.magenta;
    }
}
