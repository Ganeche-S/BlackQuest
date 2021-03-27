using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{
	public Text Text;
	public string CurrentText;

	void Start() {
		StartCoroutine(DisplayText());
	}

	public void LaunchGame() {
		FindObjectOfType<AudioManager>().Play("Select");
		SceneManager.LoadScene("Game");
	}

	private IEnumerator DisplayText() {
		Text.text = "";

		foreach(char c in CurrentText.ToCharArray()) {
			Text.text += c;
			yield return new WaitForSecondsRealtime(0.1f);
		}
		yield return new WaitForSecondsRealtime(3f);
			SceneManager.LoadScene("Game");
	}
}
