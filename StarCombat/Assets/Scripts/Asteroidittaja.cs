using UnityEngine;
using System.Collections;

public class Asteroidittaja : MonoBehaviour {

	// Use this for initialization
	//void Start () { NO EI VITTU MITÄÄN }

    public float rpm = 10.0f;

    
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 0, 6 * rpm * Time.deltaTime);
	}
}
