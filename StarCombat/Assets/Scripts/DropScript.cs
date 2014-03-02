using UnityEngine;
using System.Collections;

public class DropScript : MonoBehaviour {

    public int HpBoost = 1;

/*	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}*/

    void OnTriggerEnter2D(Collider2D collider)
    {
        PlayerScript playa = collider.gameObject.GetComponent<PlayerScript>();

        if (playa != null)
        {
            HealthScript helat = playa.gameObject.GetComponent<HealthScript>();
            helat.hp += HpBoost;
            Destroy(gameObject);
        }
    }
}
