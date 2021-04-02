using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Epilogue : MonoBehaviour {

	public Text Text;
	public string CurrentText;

	void Start() {
		FindObjectOfType<AudioManager>().Play("Epilogue");
		StartCoroutine(DisplayText());
	}

	public void LaunchCredit() {
		FindObjectOfType<AudioManager>().Play("Select");
		SceneManager.LoadScene("Credit");
	}

	private IEnumerator DisplayText() {
		Text.text = "";

		foreach(char c in CurrentText.ToCharArray()) {
			Text.text += c;
			yield return new WaitForSecondsRealtime(0.1f);
		}
		yield return new WaitForSecondsRealtime(3f);
			SceneManager.LoadScene("Credit");
	}
}
