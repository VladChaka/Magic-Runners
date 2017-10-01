using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

	public Button startGame;

	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt("isRun", 0);

		Button btn = startGame.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}
	
	void TaskOnClick()
	{
		SceneManager.LoadScene ("Main");

		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{

		GameControl.instance.ShowHelpDisplay ();
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}
}
