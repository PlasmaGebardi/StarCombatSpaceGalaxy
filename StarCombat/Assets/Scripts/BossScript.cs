using UnityEngine;
using System.Collections;
using System.Timers;

public class BossScript : MonoBehaviour {

    private System.Timers.Timer aTimer;
    private System.Timers.Timer bTimer;
    public int time = 5000;
    private EnemyMove moveScript;
    private bool bossDead = false;
   
    
    void Update()
    {
        if (renderer.IsVisibleFrom(Camera.main) == true)
        {
            moveScript = GetComponent<EnemyMove>();
            aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = time;
            aTimer.Enabled = true;
        }
        if (bossDead)
        {
            Application.LoadLevel("Intro");
            Destroy(gameObject);
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

    public void OnDeath()
    {
        SpecialEffectsHelper.Instance.Explosion(transform.position);
        SoundEffectsHelper.Instance.MakeExplosionSound();
        
        //Destroy(gameObject);
        //Remove the sprite, otherwise level won't change since script stops running
        gameObject.renderer.enabled = false;
        System.Console.Write("Boss death");
        bTimer = new System.Timers.Timer();
        bTimer.Elapsed += new ElapsedEventHandler(SceneTransfer);
        bTimer.Interval = 5000;
        bTimer.Enabled = true;

    }

    void SceneTransfer(object source, ElapsedEventArgs e)
    {
        Debug.Log("Transfering");
        bTimer.Enabled = false;
        bossDead = true;

    }
}
