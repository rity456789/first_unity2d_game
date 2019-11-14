using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public int levelLoad = 2;
    public GameMaster gameMaster;
    public Animator anim;
    public bool isOpened = false;
    // Start is called before the first frame update
    void Start()
    {
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
