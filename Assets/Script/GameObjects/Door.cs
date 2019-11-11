using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public int levelLoad = 2;
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

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            SaveScore();
            gameMaster.newSceneText.text = ("Press E to enter");
        }
    }
 
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                SaveScore();
                SceneManager.LoadScene(levelLoad);
            }
        }
    }
 
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            gameMaster.newSceneText.text = ("");
        }
    }
 
    void SaveScore()
    {
        PlayerPrefs.SetInt("score", gameMaster.score);
    }
}
