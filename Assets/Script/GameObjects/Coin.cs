using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameMaster gameMaster;
    // Start is called before the first frame update
    void Start()
    {
        gameMaster = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Player"))
        {
            Destroy(gameObject);
            gameMaster.score += 1;
        }
    }
}
