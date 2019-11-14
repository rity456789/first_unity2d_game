using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public bool isPaused = false;
    public GameObject pauseMenu;
    public int levelRestart = 1;
    public int levelMainMenu = 0;

    // Start is called before the first frame update
    void Start()    
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
 
        }
 
        if (isPaused)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0.0f;
        }
        else
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1.0f;
        }
    }

    public void Resume()
    {
        isPaused = false;
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
