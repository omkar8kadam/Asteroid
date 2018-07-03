using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlSelection : MonoBehaviour {

    public GameObject l, r, f, l1, r1, f1;
    public Toggle t0,t1;
    
	// Use this for initialization
	void Start () {
        if (PlayerPrefs.GetInt("Control") == 0)
        {
            setC0();
            t0.isOn = true;
        }
        else
        {
            setC1();
            t0.isOn = false;
            t1.isOn = true;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (t0.isOn == true)
        {
            PlayerPrefs.SetInt("Control", 0);
            setC0();
        }
        else
        {
            PlayerPrefs.SetInt("Control", 1);
            setC1();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Title");
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

    public void back()
    {
        SceneManager.LoadScene("Title");
    }
}
