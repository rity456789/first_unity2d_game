using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door2 : MonoBehaviour
{
    public GameMaster gameMaster;
    public SoundManager soundManager;
    public Animator anim;
    public bool isOpened = false;
    public GameObject endMenu;
    public Text victory;
    public Text scoreGotten;

    private bool isEnded = false;
    // Start is called before the first frame update
    void Start()
    {
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        gameMaster = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnded)
        {
            Time.timeScale = 0.0f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }

        anim.SetBool("isOpened", isOpened);        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            SaveScore();
            soundManager.PlayKnockDoorSound();
            isOpened = true;
            gameMaster.newSceneText.text = ("Press E escape here");
        }
    }
 
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                soundManager.PlayVictorySound();
                endMenu.SetActive(true);
                isEnded = true;
                scoreGotten.text = ("Score: " + gameMaster.score);
                gameMaster.newSceneText.text = ("");
                if (gameMaster.score > PlayerPrefs.GetInt("highScore"))
                {
                    victory.text = ("You break the record");
                    PlayerPrefs.SetInt("highScore", gameMaster.score);
                }
                //screen
            }
        }
    }
 
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            isOpened = false;
            gameMaster.newSceneText.text = ("");
        }
    }
 
    void SaveScore()
    {
        PlayerPrefs.SetInt("score", gameMaster.score);
        if (PlayerPrefs.GetInt("highScore") < gameMaster.score) PlayerPrefs.SetInt("highScore", gameMaster.score);
    }
}
