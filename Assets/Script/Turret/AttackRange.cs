using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRange : MonoBehaviour
{
    public TurretAI turret;
    public bool isRight = false;

    private void Awake()
    {
        turret = gameObject.GetComponentInParent<TurretAI>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            turret.Attack(isRight);
        }
    }
}
