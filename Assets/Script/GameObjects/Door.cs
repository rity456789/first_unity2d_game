using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public int levelLoad = 2;
    public GameMaster gameMaster;
    public SoundManager soundManager;
    public Animator anim;
    public bool isOpened = false;
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
        anim.SetBool("isOpened", isOpened);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            SaveScore();
            soundManager.PlayKnockDoorSound();
            isOpened = true;
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
            isOpened = false;
            gameMaster.newSceneText.text = ("");
        }
    }
 
    void SaveScore()
    {
        PlayerPrefs.SetInt("score", gameMaster.score);
    }
}
