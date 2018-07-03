using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetPlayerScript : MonoBehaviour {

    public Text starScoreText;
    public Button btnP1,btnP2;

    // Use this for initialization
    void Start () {
        starScoreText.text = PlayerPrefs.GetInt("TotalStarCount").ToString();
        if (PlayerPrefs.GetInt("TotalStarCount") < 100)
            btnP1.interactable = false; 
        if (PlayerPrefs.GetInt("TotalStarCount") < 500)
            btnP2.interactable = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Title");
        }
    }

    public void goBack()
    {
        SceneManager.LoadScene("Title");
    }

    public void setPlayer1()
    {
        PlayerPrefs.SetInt("PlayerShip", 1);
    }

    public void setPlayer2()
    {
        PlayerPrefs.SetInt("PlayerShip", 2);
    }

    public void setPlayer3()
    {
        PlayerPrefs.SetInt("PlayerShip", 3);
    }
}
