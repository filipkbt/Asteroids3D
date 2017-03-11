using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{

	void Start () {
	}
	public void PlayButton()
	{
		SceneManager.LoadScene("scena1withsounds");
	}
	public void ExitButton()
	{
		Application.Quit();
	}
	void Update () {}

}
