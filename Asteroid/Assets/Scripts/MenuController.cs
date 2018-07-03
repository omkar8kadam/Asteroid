using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

    public GameObject audioOnIcon;
    public GameObject audioOffIcon;
    public Text highScore;
    public Text totalStarCount;
    public GameObject p1, p2, p3;

    // Use this for initialization
    void Start ()
    {

        if (PlayerPrefs.GetInt("PlayerShip") == 2)
            p2.SetActive(true);
        else if (PlayerPrefs.GetInt("PlayerShip") == 3)
            p3.SetActive(true);
        else
            p1.SetActive(true);

        SetSoundState();
        highScore.text = "HIGH SCORE : " + PlayerPrefs.GetInt("HighScore").ToString();
        totalStarCount.text = PlayerPrefs.GetInt("TotalStarCount").ToString();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("exit");
            Application.Quit();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void Select_Player()
    {
        SceneManager.LoadScene("SelectPlayer");
    }

    public void ToggleSound()
    {
        if(PlayerPrefs.GetInt("Muted",0)==0)
        {
            PlayerPrefs.SetInt("Muted", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Muted", 0);
        }
        SetSoundState();
    }

    private void SetSoundState()
    {
        if (PlayerPrefs.GetInt("Muted", 0) == 0)
        {
            AudioListener.volume = 1;
            audioOnIcon.SetActive(true);
            audioOffIcon.SetActive(false);
        }
        else
        {
            AudioListener.volume = 0;
            audioOnIcon.SetActive(false);
            audioOffIcon.SetActive(true);
        }
    }

    public void ControlScene()
    {
        SceneManager.LoadScene("ControlOptions");
    }

    public void TutorialScene()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void rateGame()
    {
        Application.OpenURL("market://details?id=com.EightKApps.Asteroid");
    }
}
