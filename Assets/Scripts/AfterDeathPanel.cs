//skrypt AfterDeathPanel - podpiety do AfterDeathPanel

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AfterDeathPanel : MonoBehaviour
{
    public InputField InputField;
    public Text endscore;
    public GameObject emptyNickTxt;
    // public string name;
    // public int number;

    public void Start()
    {
        emptyNickTxt.SetActive(false);
        ScoreBoard scoreboard = GetComponent<ScoreBoard>();
        GameObject thePlayer = GameObject.Find("thePlayer");


    }



    public void PlayAgainBtn()
    {
        GameObject Spawner = GameObject.Find("Spawner");
        ScoreBoard scoreboard = Spawner.GetComponent<ScoreBoard>();
        if (InputField.text == "")
        {
            emptyNickTxt.SetActive(true);
        }
        else
        {
            
            scoreboard.AddScore(InputField.text, System.Convert.ToInt32(endscore.text));
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }

    public void ReturnBtn()
    {
        GameObject Spawner = GameObject.Find("Spawner");
        ScoreBoard scoreboard = Spawner.GetComponent<ScoreBoard>();
        if (InputField.text == "")
        {
            emptyNickTxt.SetActive(true);
        }
        else
        {
           
            scoreboard.AddScore(InputField.text, System.Convert.ToInt32(endscore.text));
            SceneManager.LoadScene("gui");
        }
    }
}
