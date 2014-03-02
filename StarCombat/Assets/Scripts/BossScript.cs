using UnityEngine;
using System.Collections;
using System.Timers;

public class BossScript : MonoBehaviour {

    private System.Timers.Timer aTimer;
    private System.Timers.Timer bTimer;
    private System.Timers.Timer cTimer;
    private System.Timers.Timer dTimer;
    public int time = 5000;
    private EnemyMove moveScript;
    private bool bossDead = false;
    private bool bossStopped = false;
    private bool help = true;
    private ScrollingScript scrollingScript;
    private GameObject boss;
    private float posX;
    private float counter = 0;
    private float counter2 = 0;
    private bool dash = true;
    private WeaponScript[] weapons;

    void Start() {
        cTimer = new System.Timers.Timer(3000);
        cTimer.Elapsed += new ElapsedEventHandler(BossMovement);
        cTimer.Enabled = true;
        GameObject player = GameObject.Find("Player");
        boss = GameObject.Find("AlffaBossi");
        scrollingScript = player.GetComponent<ScrollingScript>();
        weapons = GetComponentsInChildren<WeaponScript>();
        moveScript = GetComponent<EnemyMove>();
        aTimer = new System.Timers.Timer();
        aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        aTimer.Interval = time;
        aTimer.Enabled = true;
        bossStopped = true;
 
        /*dTimer = new System.Timers.Timer(10000);
        dTimer.Elapsed += new ElapsedEventHandler(BossDash);
        dTimer.Enabled = true;*/
    }
    void Update()
    {
        posX = transform.position.x;
        counter += Time.deltaTime;
        counter2 += Time.deltaTime;
        if (bossDead)
        {
            Application.LoadLevel("Outro");
            Destroy(gameObject);
        }

            //scrollingScript.enabled = false;
            if (help)
            {
                moveScript.direction.y = -1f;
                moveScript.speed.y = 2;
                help = false;
        }
            int a = (int)counter;
            //Debug.Log(a);
            if (a == 10)
            {
                BossDash();
                counter = 0;
            }
        var dist = (transform.position - Camera.main.transform.position).z;
            if (moveScript.direction.x == 1f & transform.position.x > Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x)
            {
                moveScript.direction.x = 0;

                int random = Random.Range(1, 100);
                if (random < 50) moveScript.direction.y = 1f;
                else moveScript.direction.y = -1f;
                cTimer.Enabled = true;
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

    void BossDash()
    {
        
        cTimer.Enabled = false;
        dTimer = new System.Timers.Timer(1000);
        dTimer.Elapsed += new ElapsedEventHandler(BossDashHelp);
        dTimer.Enabled = true;
        posX = moveScript.direction.y;
        moveScript.direction.y = 0;
        moveScript.speed.x = 5f;
        moveScript.direction.x = -1f;
    }

    void BossDashHelp(object source, ElapsedEventArgs e)
    {

        moveScript.direction.x = 1f;
        dTimer.Enabled = false;
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
        foreach(WeaponScript weapon in weapons)
        {
            weapon.enabled = false;
        }
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
        bTimer.Enabled = false;
        bossDead = true;

    }
}
