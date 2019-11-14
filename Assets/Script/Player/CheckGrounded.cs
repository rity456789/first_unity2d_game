using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGrounded : MonoBehaviour
{
    public MovingFRPlat plat;
    public Player player;
    public float inWaterCd = 6;

    void Start()
    {
        player = gameObject.GetComponentInParent<Player>();
        plat = GameObject.FindGameObjectWithTag("MovingFRPlat").GetComponent<MovingFRPlat>();
    }

    void Update()
    {
        if (player.isSwimming)
        {
            if(inWaterCd > 0)
            {
                inWaterCd -= Time.deltaTime;
            }
            else{
                player.DecreaseHP(1);
                inWaterCd = 6;
            }
        }
    }

    void FixedUpdate()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(!col.isTrigger) player.isGrounded = true;
        else if (col.CompareTag("Water")){
            player.isSwimming = true;
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if(!col.isTrigger) player.isGrounded = true;
        else if (col.CompareTag("Water")){
            player.isSwimming = true;
        }
        if(!col.isTrigger && col.CompareTag("MovingFRPlat"))
        {
            Vector3 pos = player.transform.position;
            pos.x += plat.speed * 1.5f;
            player.transform.position = pos;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if(!col.isTrigger) player.isGrounded = false;
        else if (col.CompareTag("Water")){
            player.isSwimming = false;
            inWaterCd = 6;
        }
    }
}
