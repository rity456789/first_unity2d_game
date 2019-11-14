using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
    public int dmg = 20;  
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        //delay 0.1s due to the animation
        if (col.isTrigger != true && col.CompareTag("Enemy"))
        {
            StartCoroutine(delayForAnimation(col, 0.1f));            
        }
    }

    IEnumerator delayForAnimation (Collider2D col, float time)
    {
        yield return new WaitForSeconds(time);
        col.SendMessageUpwards("Damage", dmg);
        yield return 0;
    }
}
