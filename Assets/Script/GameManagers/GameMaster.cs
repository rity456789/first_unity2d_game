using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    public int score = 0;
    public int highScore = 0;

    public Text scoreText;
    public Text highScoreText;
    public Text newSceneText;

    public Player player;

    public int curBuildIndexScene = 1;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponentInParent<Player>();

        highScoreText.text = ("HighScore: " + PlayerPrefs.GetInt("highScore"));
        highScore = PlayerPrefs.GetInt("highScore", 0);
 
        if (PlayerPrefs.HasKey("score"))
        {
            Scene activeScreen = SceneManager.GetActiveScene();
            if (activeScreen.buildIndex == curBuildIndexScene)
            {
                PlayerPrefs.DeleteKey("score");
                score = 0;
            }
            else
                score = PlayerPrefs.GetInt("score");
        }
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = ("Score: " + score);
        if (player.curHP <= 0)
        {
            if (PlayerPrefs.GetInt("highScore") < score) PlayerPrefs.SetInt("highScore", score);
            PlayerPrefs.DeleteKey("score");
        }
    }
}
