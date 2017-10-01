using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour {

	public Button pauseButton;

	// Use this for initialization
	void Start () {
		
		Button btnPause = pauseButton.GetComponent<Button>();
		btnPause.onClick.AddListener (Pause);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Pause() {

		print ("pause");

		Time.timeScale = 0;
	}

	void Resume() {

		Time.timeScale = 1;
	}
}
