using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour {

    // speed of the object
    public Vector2 speed = new Vector2(10, 10);

    // static movement direciton
    public Vector2 direction = new Vector2(-1, 0);

    // vector for storing movement info
    public Vector2 movement;
	
	// Update is called once per frame
	void Update () {
        movement = new Vector2(
            speed.x * direction.x,
            speed.y * direction.y);
	}

    void FixedUpdate()
    {
        rigidbody2D.velocity = movement;
    }
}
