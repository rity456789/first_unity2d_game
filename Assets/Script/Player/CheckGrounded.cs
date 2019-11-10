using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGrounded : MonoBehaviour
{
    public Player player;

    void Start()
    {
        player = gameObject.GetComponentInParent<Player>();
    }

    void FixedUpdate()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.isTrigger) player.isGrounded = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(!collision.isTrigger) player.isGrounded = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(!collision.isTrigger) player.isGrounded = false;
    }
}
