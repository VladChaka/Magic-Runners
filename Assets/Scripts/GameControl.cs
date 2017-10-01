using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using GoogleMobileAds;
using GoogleMobileAds.Api;

public class GameControl : MonoBehaviour 
{
	public static GameControl instance;			//A reference to our game control script so we can access it statically.
	public Text scoreText;						//A reference to the UI text component that displays the player's score.
	public GameObject gameOvertext;				//A reference to the object that displays the text which appears when the player dies.
	public GameObject HelpPanel;
	public GameObject shot;

	private int score = 0;						//The player's score.
	public bool gameOver = false;				//Is the game over?
	public bool isRun = true;
	public float scrollSpeed = -1.5f;


	void Awake()
	{
		isRun = PlayerPrefs.GetInt("isRun") == 1 ? true : false;

		RequestBanner ();

		//If we don't currently have a game control...
		if (instance == null)
			//...set this one to be it...
			instance = this;
		//...otherwise...
		else if(instance != this)
			//...destroy this one because it is a duplicate.
			Destroy (gameObject);
	}

	void Update()
	{
		//If the game is over and the player has pressed some input...
		if (!isRun && Input.GetMouseButtonDown (0)) {

			isRun = true;

			PlayerPrefs.SetInt("isRun", isRun ? 1 : 0);

			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}

		if (gameOver && Input.GetMouseButtonDown(0)) 
		{
			//...reload the current scene.
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}

	public void HeroScored()
	{
		//The bird can't score if the game is over.
		if (gameOver)	
			return;
		//If the game is not over, increase the score...
		score += 1;

		//...and adjust the score text.
		scoreText.text = "SCORE: " + score.ToString();
	}

	public void ShowHelpDisplay() 
	{
		//Activate the game over text.
		HelpPanel.SetActive (true);
		//Set the game to be over.
		isRun = false;
	}

	public void HeroDied()
	{
		//Activate the game over text.
		gameOvertext.SetActive (true);
		//Set the game to be over.
		gameOver = true;
	}

	private void RequestBanner()
	{
		#if UNITY_EDITOR
		string adUnitId = "unused";
		#elif UNITY_ANDROID
		string adUnitId = "ca-app-pub-3750221839589294/9983416717";
		#elif UNITY_IPHONE
		string adUnitId = "ca-app-pub-3750221839589294/3770605423";
		#else
		string adUnitId = "unexpected_platform";
		#endif


		// Create a 320x50 banner at the top of the screen.
		BannerView bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);
		// Create an empty ad request.
		AdRequest request = new AdRequest.Builder().Build();
		// Load the banner with the request.
		bannerView.LoadAd(request);
	}
}
