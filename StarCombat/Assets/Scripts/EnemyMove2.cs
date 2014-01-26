using UnityEngine;

/// <summary>
/// Simply moves the current game object
/// </summary>
public class EnemyMove2 : MonoBehaviour
{
    // 1 - Designer variables

    /// <summary>
    /// Object speed
    /// </summary>
    public Vector2 speed = new Vector2(3, 3);

    /// <summary>
    /// Moving direction
    /// </summary>
    public Vector2 direction = new Vector2(-1, 0.2f);

    private Vector2 movement;
    private int count;
    void Update()
    {
        // 2 - Movement
        if (count == 50)
        {
            if (direction.y == 0.2f)
            {
                direction.y = -0.2f;
            }
            else
            {
                direction.y = 0.2f;
            }
            count = 0;
        }
        count++;
        movement = new Vector2(
          speed.x * direction.x,
          speed.y * direction.y);
    }

    void FixedUpdate()
    {
        // Apply movement to the rigidbody
        rigidbody2D.velocity = movement;
    }
}