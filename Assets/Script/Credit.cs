using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Credit : MonoBehaviour {

	void Start() {
		StartCoroutine(EndCredits());
	}

    public void ReturnMenu() {
		FindObjectOfType<AudioManager>().Play("Select");
		SceneManager.LoadScene("Menu");
	}

	private IEnumerator EndCredits() {
		yield return new WaitForSecondsRealtime(50f);
			SceneManager.LoadScene("Menu");
	}
}
