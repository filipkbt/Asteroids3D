using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseWindow : MonoBehaviour {

    public void Start()
    {
      


    }

    public void Update()
    {

    }
    public void StopPause()
    {
        Time.timeScale = 1;
        ShipGui shipGui = GetComponent<ShipGui>();
        shipGui.pauseWindow.SetActive(false);
       
    }

    public void PlayAgainPauseBtn()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void ReturnPauseBtn()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("gui");
    }
}
