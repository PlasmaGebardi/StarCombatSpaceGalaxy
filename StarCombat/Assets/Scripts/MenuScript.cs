using UnityEngine;
using System.Collections;
/// <summary>
/// Script for menu and starting the game
/// </summary>
public class MenuScript : MonoBehaviour {

    void OnGUI()
    {
        // button size
        const int buttonWidth = 200;
        const int buttonHeight = 100;

        if (GUI.Button(
            new Rect(
                Screen.width / 2 - (buttonWidth / 2),
                (2 * Screen.height / 3) - (buttonHeight / 2),
                buttonWidth,
                buttonHeight
                ),
            "Start"
            )
        )
        {   // launch the first (currently only level)
            Application.LoadLevel("StarCombat");
        }
    }


	// Use this for initialization
	//void Start () {
	
	//}
	
	// Update is called once per frame
	//void Update () {
	
	//}
}
