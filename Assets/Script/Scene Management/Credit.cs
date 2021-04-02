using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Credit : MonoBehaviour {

	void Start() {
		FindObjectOfType<AudioManager>().Play("Credit");
		StartCoroutine(EndCredits());
	}

    public void ReturnMenu() {
		FindObjectOfType<AudioManager>().Play("Select");
		SceneManager.LoadScene("Menu");
	}

	public void QuitGame() {
		FindObjectOfType<AudioManager>().Play("Select");
		Application.Quit();
	}

	private IEnumerator EndCredits() {
		yield return new WaitForSecondsRealtime(50f);
			SceneManager.LoadScene("Menu");
	}
}
