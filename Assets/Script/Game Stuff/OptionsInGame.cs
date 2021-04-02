using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsInGame : MonoBehaviour {
	
	public void RestartGame() {
		FindObjectOfType<AudioManager>().Play("Select");
	}

	public void Exit() {
		FindObjectOfType<AudioManager>().Play("Select");
		SceneManager.LoadScene("Menu");
	}

	public void QuitGame() {
		FindObjectOfType<AudioManager>().Play("Select");
		Application.Quit();
	}
}
