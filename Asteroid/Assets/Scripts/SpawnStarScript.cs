using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnStarScript : MonoBehaviour
{

    public GameObject star;
    public Vector3 spawnValues;
    public int starCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    private GameController gameController;

    public Text starScoreText;
    private int starScore;

    void Start ()
    {
        starScore = 0;
        UpdateStarScore();

        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        StartCoroutine(SpawnStars());
    }
	
	void Update ()
    {
		
	}

    IEnumerator SpawnStars()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < starCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Instantiate(star, spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
            if (gameController.gameOver)
            {
                break;
            }
        }
    }

    public void AddStarScore(int newStarScoreValue)
    {
        starScore += newStarScoreValue;
        int currTotalStarCount = PlayerPrefs.GetInt("TotalStarCount");
        PlayerPrefs.SetInt("TotalStarCount", currTotalStarCount+1);
        UpdateStarScore();
    }

    void UpdateStarScore()
    {
        starScoreText.text = "" + starScore;
    }
}
