using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFRPlat : MonoBehaviour
{
    public float speed = 0.04f;
    Vector3 Move;

    public PauseMenu pauseMenu;
    public DeadMenu deadMenu;

    // Start is called before the first frame update
    void Start()
    {
        Move = transform.position;

        pauseMenu = GameObject.FindGameObjectWithTag("MainCamera").GetComponentInParent<PauseMenu>();
        deadMenu = GameObject.FindGameObjectWithTag("MainCamera").GetComponentInParent<DeadMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!pauseMenu.isPaused && !deadMenu.isDeaded)
        {
            Move.x += speed;
            transform.position = Move;
        }    
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Ground"))
        {
            speed *= -1;
        }
    }
}
