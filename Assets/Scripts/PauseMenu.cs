using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public string mainMenuLevel;

	public GameObject pauseMenu;

	public void PauseGame()
	{
		Time.timeScale = 0f;
		pauseMenu.SetActive(true);
	}

	public void ResumeGame()
	{
		Time.timeScale = 1f;
		pauseMenu.SetActive(false);
	}

	public void RestartGame()
	{
		FindObjectOfType<GameManager>().Reset();
		pauseMenu.SetActive(false);
		Time.timeScale = 1f;
	}

	public void QuitToMain()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene(mainMenuLevel);
		//Application.LoadLevel(mainMenuLevel);
	}
}
