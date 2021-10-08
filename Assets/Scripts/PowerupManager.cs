using UnityEngine;
using System.Collections;

public class PowerupManager : MonoBehaviour {

	private bool doublePoints;
	private bool safeMode;

	private bool powerUpActive;

	private float powerupLengthCounter;

	private GameManager theGameManager;
	private ScoreManager theScoreManager;
	private PlatformGenerator thePlatformGenerator;

	private float normalPointPerSecond;
	private float spikeRate;

	private PlatformDestroyer[] spikeList;


	// Use this for initialization
	void Start () {
		 theScoreManager = FindObjectOfType<ScoreManager>();
		 thePlatformGenerator = FindObjectOfType<PlatformGenerator>();
		 theGameManager = FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {

		if(powerUpActive)
		{
			powerupLengthCounter -= Time.deltaTime;

			if(theGameManager.powerupReset)
			{
				powerupLengthCounter = 0;
				theGameManager.powerupReset = false;

			}
			if(doublePoints && powerupLengthCounter <= 0)
			{
				theScoreManager.pointPerSecond = normalPointPerSecond * 2.5f;
				theScoreManager.shouldDouble = true;
			}

			if(safeMode && powerupLengthCounter <= 0)
			{
				thePlatformGenerator.randomSpikeThreshold = 0f;
			}

			if(powerupLengthCounter <=0)
			{
				ResetPowerUp();
			}		
		}
	}

	public void ActivatePowerup(bool points, bool safe, float time)
	{
		doublePoints = points;
		safeMode = safe;
		powerupLengthCounter = time;
		normalPointPerSecond = theScoreManager.pointPerSecond;
		spikeRate = thePlatformGenerator.randomSpikeThreshold;

		if(safeMode)
		{
			
			spikeList = FindObjectsOfType<PlatformDestroyer>();
				for(int i =0; i < spikeList.Length; i++)
					{	
						if(spikeList[i].gameObject.name.Contains("spikes"))
						{
							spikeList[i].gameObject.SetActive(false);
						}
					}
		}
		powerUpActive = true;
	}

	public void ResetPowerUp()
	{
		theScoreManager.pointPerSecond = normalPointPerSecond;
		theScoreManager.shouldDouble = false;
		thePlatformGenerator.randomSpikeThreshold = spikeRate;
		powerUpActive = false;
	}
}
