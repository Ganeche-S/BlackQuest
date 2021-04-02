using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

	void Start() {
		FindObjectOfType<AudioManager>().Play("Menu");
	}

	public void PlayGame() {
		FindObjectOfType<AudioManager>().Play("Select");
		SceneManager.LoadScene("Intro");
	}

	public void Settings() {
		FindObjectOfType<AudioManager>().Play("Select");
	}

	public void QuitGame() {
		FindObjectOfType<AudioManager>().Play("Select");
		Application.Quit();
	}
}
