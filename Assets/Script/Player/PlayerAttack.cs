using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackDelay = 0.3f;
    public bool isAttacking = false;
 
    public Animator anim;
    public Collider2D trigger;

    public KeyCode attackKey = KeyCode.Z;

    public SoundManager soundManager;
    public Player player;

    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        trigger.enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        player = gameObject.GetComponent<Player>();
    }
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(attackKey) && !isAttacking && !player.isSwimming)
        {
            soundManager.PlaySwordSound();
            isAttacking = true;
            trigger.enabled = true;
            attackDelay = 0.3f;
        }
 
        if (isAttacking)
        {
            if (attackDelay > 0)
            {
                attackDelay -= Time.deltaTime;
 
            }
            else
            {
                isAttacking = false;
                trigger.enabled = false;
            }
        }
 
        anim.SetBool("isAttacking", isAttacking);
    }
}
