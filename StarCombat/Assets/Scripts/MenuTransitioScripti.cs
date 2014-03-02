using UnityEngine;
using System.Collections;
using System.Threading;

public class MenuTransitioScripti : MonoBehaviour {

    private float counter = 0f;
    //public bool ded = false;
	// Use this for initialization
	void Start () {

	}

    //public void Menuun() { ded = true; }
	// Update is called once per frame
    void Update()
    {

        if (!GameObject.Find("Player"))
        {
            counter += Time.deltaTime;
            if ((int)counter > 3) { Application.LoadLevel("Menu"); }
        }
    }
}
