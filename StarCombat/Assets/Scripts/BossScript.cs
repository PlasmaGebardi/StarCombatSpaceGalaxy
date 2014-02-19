using UnityEngine;
using System.Collections;
using System.Timers;

public class BossScript : MonoBehaviour {

    private System.Timers.Timer aTimer;
    private System.Timers.Timer bTimer;
    private System.Timers.Timer cTimer;
    public int time = 5000;
    private EnemyMove moveScript;
    private bool bossDead = false;
    private bool bossStopped = false;
    private bool help = true;
    private ScrollingScript scrollingScript;

    void Start() {
        cTimer = new System.Timers.Timer(3000);
        cTimer.Elapsed += new ElapsedEventHandler(BossMovement);
        cTimer.Enabled = true;
        GameObject player = GameObject.Find("Player");
        scrollingScript = player.GetComponent<ScrollingScript>();
    }
    void Update()
    {
        if (renderer.IsVisibleFrom(Camera.main) == true & bossStopped == false)
        {
            moveScript = GetComponent<EnemyMove>();
            aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = time;
            aTimer.Enabled = true;
            bossStopped = true;
        }

        if (bossDead)
        {
            Application.LoadLevel("Intro");
            Destroy(gameObject);
        }

        if (bossStopped)
        {
            scrollingScript.enabled = false;
            if (help)
            {
                moveScript.direction.y = -1f;
                moveScript.speed.y = 2;
                help = false;
            }
        }

    }

    void BossMovement(object source, ElapsedEventArgs e)
    {
        if (moveScript.direction.y == -1f)
        {
            moveScript.direction.y = 1f;
        }
        else 
        {
            moveScript.direction.y = -1f;
        }
    }

    // Specify what you want to happen when the Elapsed event is raised.
    void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        moveScript.speed.x = 1f;
        moveScript.speed.y = 1f;
        moveScript.direction.y = 0f;
        moveScript.direction.x = 0f;
        aTimer.Enabled = false;
        bossStopped = true;

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
