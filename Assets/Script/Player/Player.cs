using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 50f, maxSpeed = 3, maxJump = 4, jumpPow = 250f;
    public bool isGrounded = true, faceright = true, doubleJump = true, isSwimming = false;

    public Rigidbody2D r2;
    public Animator anim;
    public GameMaster gameMaster;
    public SoundManager soundManager;

    public int curHP;
    public int maxHP = 5;

    public KeyCode jumpKey = KeyCode.Space;

    //private bool isFeezedTrigger = false;   // to deny trigger enter 2 colliders

    void Start()
    {
        r2 = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        gameMaster = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        curHP = maxHP;
    }

    void Update()
    {
        // run
        anim.SetBool("isGrounded", isGrounded);
        anim.SetBool("isSwimming", isSwimming);
        anim.SetFloat("speed", Mathf.Abs(r2.velocity.x));

        // jump
        if (Input.GetKeyDown(jumpKey))
        {

            if (isGrounded)
            {
                soundManager.PlayJumpSound();
                isGrounded = false;
                doubleJump = true;
                r2.AddForce(Vector2.up * jumpPow);
            }
            else
            {
                if (doubleJump)
                {
                    soundManager.PlayJumpSound();
                    doubleJump = false;
                    r2.velocity = new Vector2(r2.velocity.x, 0);
                    r2.AddForce(Vector2.up * 0.8f * jumpPow);
                }
            }

            if (isSwimming)
            {
                soundManager.PlayJumpSound();
                r2.AddForce(Vector2.up * jumpPow);
            }            
        }

        
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        r2.AddForce((Vector2.right) * speed * h);

        // gioi han toc do chay
        if (r2.velocity.x > maxSpeed)
            r2.velocity = new Vector2(maxSpeed, r2.velocity.y);
        if (r2.velocity.x < -maxSpeed)
            r2.velocity = new Vector2(-maxSpeed, r2.velocity.y);

        //gioi han nhay
        if (r2.velocity.y > maxJump)
            r2.velocity = new Vector2(r2.velocity.x, maxJump);
        if (r2.velocity.y < -maxJump)
            r2.velocity = new Vector2(r2.velocity.x, -maxJump);

        //xoay huong nhan vat
        if (h > 0 && !faceright)
        {
            Flip();
        }
        if (h < 0 && faceright)
        {
            Flip();
        }

        //tao ma sat
        if (isGrounded || isSwimming)
        {
            r2.velocity = r2.velocity = new Vector2(r2.velocity.x * 0.8f, r2.velocity.y);
        }
    }

    public void Flip()
    {
        faceright = !faceright;
        Vector3 Scale;
        Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
    }

    public void IncreaseHP (int hp)
    {
        curHP += hp;
        //check curHP
        if (curHP > maxHP)
            curHP = 5;
 
 
        if (curHP < 0)
            curHP = 0;
    }

    public void DecreaseHP (int hp)
    {
        curHP -= hp;
        soundManager.PlayHurtSound();
        gameObject.GetComponent<Animation>().Play("damaged");
        //check curHP
        if (curHP > maxHP)
            curHP = 5;
 
 
        if (curHP < 0)
            curHP = 0;
    }

    public void KnockBack ()
    {
        r2.velocity = new Vector2(0, 0);
        r2.AddForce(new Vector2(-1000, 400));
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        //if (!isFeezedTrigger)
        {
            //isFeezedTrigger = true;
            if (col.CompareTag("Coin"))
            {
                soundManager.PlayCoinSound();
                Destroy(col.gameObject);
                gameMaster.score += 1;
            }
            else if (col.CompareTag("Heart"))
            {
                soundManager.PlayHeartSound();
                gameObject.GetComponent<Animation>().Play("heal");
                Destroy(col.gameObject);
                if (curHP < 5) curHP += 1;
            }
            else if (col.CompareTag("Shoe"))
            {
                soundManager.PlayShoeSound();
                Destroy(col.gameObject);
                maxSpeed = 4.5f;
                speed = 75f;
                StartCoroutine(normalizeSpeed(5));
            }
            else if (col.CompareTag("FullHeart"))
            {
                soundManager.PlayFullHeartSound();
                gameObject.GetComponent<Animation>().Play("heal");
                Destroy(col.gameObject);
                curHP = 5;
            }
            //StartCoroutine(unFeezeTrigger(Time.deltaTime));
        }
    }
    IEnumerator normalizeSpeed (float time)
    {
        yield return new WaitForSeconds(time);
        maxSpeed = 3f;
        speed = 50f;
        soundManager.PlayShoeOutSound();
        yield return 0;
    }

    // IEnumerator unFeezeTrigger (float time)
    // {
    //     yield return new WaitForSeconds(time);
    //     isFeezedTrigger = false;
    //     yield return 0;
    // }
}
