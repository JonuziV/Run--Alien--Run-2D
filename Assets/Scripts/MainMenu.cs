using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public string playGameLevel;
	public void Play()
	{
		SceneManager.LoadScene(playGameLevel);
		//Application.LoadLevel(playGameLevel);
	}

	public void Quit()
	{
		Application.Quit();
		Debug.Log("Quit");
	}
}
