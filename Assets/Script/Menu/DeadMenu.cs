using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadMenu : MonoBehaviour
{
    public bool isDeaded = false;
    public int levelRestart = 1;
    public int levelMainMenu = 0;

    public Player player;
    public GameObject deadMenu;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponentInParent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.curHP <= 0)
        {
            isDeaded = true;         
        }
        if (isDeaded)
        {
            
            deadMenu.SetActive(true);
            Time.timeScale = 0.0f;
        }
        
    }

    public void Restart()
    {
        SceneManager.LoadScene(levelRestart);
    }

    public void Quit()
    {
        SceneManager.LoadScene(levelMainMenu);
    }
}
