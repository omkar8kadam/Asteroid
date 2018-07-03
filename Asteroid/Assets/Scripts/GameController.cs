using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private int flg = 1;

    public GameObject p1,p2,p3;
    public GameObject p1l1, p1l2, p2l1, p2l2, p2l3, p3l1, p3l2, p3l3, p3l4, p3l5;
    public GameObject l, r, f, l1, r1, f1;

    public GameObject[] meteors;
    public Vector3 spawnValues;
    public int meteorCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text scoreText;
    private int score;

    private int health;

    public GameObject restartButton;
    public GameObject pauseButton;
    public Text gameOverText;
    public bool gameOver;

    private MoveDown moveDown;

    private int omi = 0, omi1=0, omi2=0, omi3=0;

// Use this for initialization
void Start()
    {
        if (PlayerPrefs.GetInt("PlayerShip") == 2)
            p2.SetActive(true);
        else if (PlayerPrefs.GetInt("PlayerShip") == 3)
            p3.SetActive(true);
        else
            p1.SetActive(true);

        if (PlayerPrefs.GetInt("Control") == 1)
            setC1();
        else
            setC0();

        gameOver = false;
        restartButton.SetActive(false);
        pauseButton.SetActive(true);
        gameOverText.text = "";
        score = 0;
        UpdateScore();
        UpdateHealth();
        StartCoroutine(SpawnWaves());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Title");
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            GameObject meteor;
            for (int i = 0; i < meteorCount; i++)
            {
                if (score < 10)
                    meteor = meteors[Random.Range(0, 7)];
                else if (score < 15)
                {
                    meteor = meteors[Random.Range(4, 9)];
                    if (omi1 == 0)
                    {
                        spawnWait -= 0.5f;
                        omi1 = 1;
                    }
                }
                else if (score < 25)
                {
                    meteor = meteors[Random.Range(5, 10)];
                    if (omi2 == 0)
                    {
                        spawnWait -= 0.1f;
                        omi2 = 1;
                    }
                }
                else
                {
                    meteor = meteors[Random.Range(0, meteors.Length)];
                    if (omi == 0)
                    {
                        spawnWait -= 0.2f;
                        omi = 1;
                    }
                }

                if(score>70 && omi3==0)
                {
                    spawnWait -= 0.2f;
                    omi3 = 1;
                }
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Instantiate(meteor, spawnPosition,Quaternion.identity);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                pauseButton.SetActive(false);
                restartButton.SetActive(true);
                int currHighScore = PlayerPrefs.GetInt("HighScore");
                int currScore = score;
                if(currScore > currHighScore)
                {
                    PlayerPrefs.SetInt("HighScore", currScore);
                }
                break;
            }
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "SCORE : " + score;
        int currHighScore = PlayerPrefs.GetInt("HighScore");
        int currScore = score;
        if (currScore > currHighScore)
        {
            PlayerPrefs.SetInt("HighScore", currScore);
        }
    }

    public void changeHealth(int newHealth)
    {
        health = newHealth;
        UpdateHealth();
    }

    void UpdateHealth()
    {
        if(PlayerPrefs.GetInt("PlayerShip") == 2)
        {
            if(health == 3)
            {
                p2l1.SetActive(true);
                p2l2.SetActive(true);
                p2l3.SetActive(true);
            }
            if (health == 2)
                p2l3.SetActive(false);
            if (health == 1)
                p2l2.SetActive(false);
            if (health == 0)
                p2l1.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("PlayerShip") == 3)
        {
            if(health == 5)
            {
                p3l1.SetActive(true);
                p3l2.SetActive(true);
                p3l3.SetActive(true);
                p3l4.SetActive(true);
                p3l5.SetActive(true);
            }
            if (health == 4)
                p3l5.SetActive(false);
            if (health == 3)
                p3l4.SetActive(false);
            if (health == 2)
                p3l3.SetActive(false);
            if (health == 1)
                p3l2.SetActive(false);
            if (health == 0)
                p3l1.SetActive(false);
        }
        else
        {
            if (health == 2)
            {
                p1l1.SetActive(true);
                p1l2.SetActive(true);
            }
            if (health == 1)
                p1l2.SetActive(false);
            if (health == 0)
                p1l1.SetActive(false);
        }
    }

    public void GameOver()
    {
        gameOverText.text = "GAME OVER !";
        gameOver = true;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void pauseGame()
    {
        if (flg == 1)
        {
            Time.timeScale = 0;
            flg = 0;
            GetComponent<AudioSource>().Pause();
        }
        else
        {
            Time.timeScale = 1;
            flg = 1;
            GetComponent<AudioSource>().Play();
        }
        
    }

    void setC1()
    {
        l1.SetActive(true);
        r1.SetActive(true);
        f1.SetActive(true);
        l.SetActive(false);
        r.SetActive(false);
        f.SetActive(false);
    }

    void setC0()
    {
        l.SetActive(true);
        r.SetActive(true);
        f.SetActive(true);
        l1.SetActive(false);
        r1.SetActive(false);
        f1.SetActive(false);
    }
}
