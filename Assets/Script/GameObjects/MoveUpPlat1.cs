using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpPlat1 : MonoBehaviour
{
    private float speed = 0f;
    private bool isMoved = false;
    Vector3 Move;
    public float moveUpSpeed = 0.03f;

    public PauseMenu pauseMenu;
    public DeadMenu deadMenu;

    // Start is called before the first frame update
    void Start()
    {
        Move = transform.position;
        speed = 0f;
        isMoved = false;

        pauseMenu = GameObject.FindGameObjectWithTag("MainCamera").GetComponentInParent<PauseMenu>();
        deadMenu = GameObject.FindGameObjectWithTag("MainCamera").GetComponentInParent<DeadMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!pauseMenu.isPaused && !deadMenu.isDeaded)
        {
            Move.y += speed;
            transform.position = Move;
        }    
    }



    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Player") && !isMoved)
        {
            speed = moveUpSpeed;
            isMoved = true;
        }
        else if (col.collider.CompareTag("Ground"))
        {
            speed = 0f;
        }
    }
}
