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

    void OnTriggerEnter2D(Collider2D col)
    {
        if(!col.isTrigger) player.isGrounded = true;
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if(!col.isTrigger || col.CompareTag("Water")) player.isGrounded = true;
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if(!col.isTrigger || col.CompareTag("Water")) player.isGrounded = false;
    }
}
