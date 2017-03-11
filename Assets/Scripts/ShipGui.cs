using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class ShipGui : MonoBehaviour {

	#region Constants
	private const string ThePlayer = "ThePlayer";
    #endregion

   // private bool flag  = false;
	#region Public Variables
	public int Score = 0;
    public Text ScoreTxt;
    public Slider healthBar;
    public Text SpeedTxt;
    public GameObject image;
    public GameObject afterDeathPanel;
    public GameObject afterDeathCamera;
    public GameObject gui;
    public GameObject pauseWindow;
    public Text finalScoreTxt;
    #endregion

    public void Start()
    {
        afterDeathPanel.SetActive(false);
        afterDeathCamera.SetActive(false);
        pauseWindow.SetActive(false);
    }
    void OnGUI()
    {
        
        Vector2 pozycjaCelownika = Input.mousePosition;
        if ((pozycjaCelownika.x - (Screen.width / 2)) > -100 && (pozycjaCelownika.x - (Screen.width / 2)) < 100)
        {
            pozycjaCelownika.x = 0;
        }
        else
        {
            pozycjaCelownika.x = pozycjaCelownika.x - (Screen.width / 2);
        }
        if ((pozycjaCelownika.y - (Screen.height / 2)) > -100 && (pozycjaCelownika.y - (Screen.height / 2)) < 100)
        {
            pozycjaCelownika.y = 0;
        }
        else
        {
            pozycjaCelownika.y = pozycjaCelownika.y - (Screen.height / 2);
        }

    
        GameObject thePlayer = GameObject.Find(ThePlayer);
        
        MyControl myControl = thePlayer.GetComponent<MyControl>();
        ScoreTxt.text = Score.ToString();
        healthBar.value = myControl.Health;
        SpeedTxt.text = myControl.trueSpeed.ToString();
        ShowBoost();
        ShowWindowAfterDeath(myControl.Health);
	}

    public void ShowBoost()
    {
        image.SetActive(false);
        if (Input.GetKey(KeyCode.LeftShift))
        {
            image.SetActive(true);

        }
     }

    public void ShowWindowAfterDeath(int health)
    {
        
        if(health<= 0)
        {
            finalScoreTxt.text = Score.ToString();
            gui.SetActive(false);
            afterDeathCamera.SetActive(true);
            afterDeathPanel.SetActive(true);
        }
    }
}
