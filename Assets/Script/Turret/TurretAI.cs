using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAI : MonoBehaviour
{

    public int curHealth = 100;
 
    public float distance;
    public float wakerange = 8;
    public float shootinterval = 4;
    public float bulletspeed = 5;
    public float bullettimer;
 
    public bool awake = false;
    public bool lookRight = false;
 
    public GameObject bullet;
    public Transform target;
    public Animator anim;
    public Transform shootPointLeft, shootPointRight;
    public SoundManager soundManager;

    private void Awake()
    {
        anim = GetComponent<Animator>();      
    }

    // Start is called before the first frame update
    void Start()
    {
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Awake", awake);
        anim.SetBool("LookRight", lookRight);
 
        RangeCheck();
 
        if (target.transform.position.x > transform.position.x)
        {
            lookRight = true;
        }
        else if (target.transform.position.x < transform.position.x)
        {
            lookRight = false;
        }
 
        if (curHealth < 0)
        {
            soundManager.PlayCrashSound();
            Destroy(gameObject);
        }
    }

    void RangeCheck()
    {
        distance = Vector2.Distance(transform.position, target.transform.position);
 
        if (distance < wakerange)
            awake = true;
 
        if (distance > wakerange)
            awake = false;
    }
 
    public void Attack(bool attackright)
    {
        bullettimer += Time.deltaTime;
 
        if (bullettimer >= shootinterval)
        {
            Vector2 direction = target.transform.position - transform.position;
            direction.Normalize();
 
            if (attackright)
            {
                GameObject bulletclone;
                bulletclone = Instantiate(bullet, shootPointRight.transform.position, shootPointRight.transform.rotation) as GameObject;
                bulletclone.GetComponent<Rigidbody2D>().velocity = direction * bulletspeed;
 
                bullettimer = 0;
            }
            else
            {
                GameObject bulletclone;
                bulletclone = Instantiate(bullet, shootPointLeft.transform.position, shootPointLeft.transform.rotation) as GameObject;
                bulletclone.GetComponent<Rigidbody2D>().velocity = direction * bulletspeed;
 
                bullettimer = 0;
            }
        }
    }
 
    public void Damage(int dmg)
    {
        curHealth -= dmg;
        gameObject.GetComponent<Animation>().Play("damaged");
    }
}
