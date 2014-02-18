using UnityEngine;
using System.Collections;
using System.Timers;

public class BossScript : MonoBehaviour {

    System.Timers.Timer aTimer = new System.Timers.Timer();
    public int time = 5000;
    private EnemyMove moveScript;

    void Update()
    {
        if (renderer.IsVisibleFrom(Camera.main) == true)
        {
            moveScript = GetComponent<EnemyMove>();
            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = time;
            aTimer.Enabled = true;
        }
    }

    // Specify what you want to happen when the Elapsed event is raised.
    void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        moveScript.speed.x = 1f;
        moveScript.speed.y = 1f;
        moveScript.direction.y = 0f;
        moveScript.direction.x = 0.1f;
        aTimer.Enabled = false;
    }


}
