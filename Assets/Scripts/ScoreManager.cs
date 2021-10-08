using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text scoreText;
	public Text highscoreText;

	public float scoreCount;
	public float highscoreCount;

	public float pointPerSecond;
	public bool scoreIncreasing;

	public bool shouldDouble;

	// Use this for initialization
	void Start () {
		 if(PlayerPrefs.HasKey("Highscore"))
	 		{
	 			highscoreCount = PlayerPrefs.GetFloat("Highscore");
	 		}
	}
	
	// Update is called once per frame
	void Update () {

		if (scoreIncreasing)
		{
			scoreCount += pointPerSecond * Time.deltaTime;
		}

		if(scoreCount > highscoreCount)
		{
			highscoreCount = scoreCount;
			PlayerPrefs.SetFloat("Highscore", highscoreCount);
		}

		scoreText.text = "Score: " + Mathf.Round(scoreCount);
		highscoreText.text = "Highscore: " + Mathf.Round(highscoreCount);
	}

	public void AddScore(int pointsToAdd)
	{
		scoreCount += pointsToAdd;
		if(shouldDouble)
		{
			pointsToAdd = pointsToAdd * 2;
		}
	}
}
