using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public float scrollingSpeed = -1.5f;
    public bool gameOver = false;
    public GameObject gameoverText;
    public Text scoreText;
    public GameObject tapToPlay;

    private int score = 0;
    private bool firstTime = true;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        gameoverText.SetActive(false);
        tapToPlay.SetActive(true);
        Time.timeScale = 0;        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && (firstTime == true || gameOver == true))
        {
            if (gameOver)
            {
                StartGame();
                gameOver = false;
            }
            else if (firstTime)
            {

                tapToPlay.SetActive(false);
                Time.timeScale = 1;
            }           
           // else
        }
    }

    public void BirdDie()
    {
        gameOver = true;
        gameoverText.SetActive(true);
    }

    public void BirdScored()
    {
        if (gameOver) return;
        score ++;

        scoreText.text = "Score: " + score.ToString();
        firstTime = false;
        UpdateScrollingSpeed();
    }

    public int GetScore()
    {
        return score;
    }

    void UpdateScrollingSpeed()
    {
        if (score > 0 &&score %10 == 0)
        {
            scrollingSpeed -= 0.25f;
        }
    }

    private void StartGame()
    {
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
