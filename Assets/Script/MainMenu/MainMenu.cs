using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public int levelPlay = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        SceneManager.LoadScene(levelPlay);
    }
 
    public void Setting()
    {
        mainMenu.SetActive(false);
    }
 
    public void Quit()
    {
        Application.Quit();
    }
}
