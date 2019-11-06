using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 50f, maxSpeed = 3, maxJump = 4, jumpPow = 250f;
    public bool isGrounded = true, faceright = true, doubleJump = true;

    public Rigidbody2D r2;
    public Animator anim;

    public int curHP;
    public int maxHP = 5;

    void Start()
    {
        r2 = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        curHP = maxHP;
    }

    void Update()
    {
        // run
        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("speed", Mathf.Abs(r2.velocity.x));

        // jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                isGrounded = false;
                doubleJump = true;
                r2.AddForce(Vector2.up * jumpPow);
            }
            else
            {
                if (doubleJump)
                {
                    doubleJump = false;
                    r2.velocity = new Vector2(r2.velocity.x, 0);
                    r2.AddForce(Vector2.up * 0.8f * jumpPow);
                }
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
        if (isGrounded)
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
}
