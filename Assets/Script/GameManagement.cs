using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagement : MonoBehaviour {

	public Boss boss;
	public KnightMovement player;

	public void Restart() {
		SceneManager.LoadScene("Game");
	}

	public void Exit() {
		SceneManager.LoadScene("Menu");
	}

	public void SetActiveTrue() {
		this.gameObject.SetActive(true);
	}

	public void gameWinOrDefeat() {
		if(boss.currentHealth <= 0) {
        	player.myRigidbody.isKinematic = true;
            player.myRigidbody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        }
        if(player.currentHealth.RuntimeValue <= 0) {
        	player.myRigidbody.isKinematic = true;
            player.myRigidbody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        }
	}

	public bool playerIsAlive() {
		if(player.currentHealth.RuntimeValue > 0) {
			return true;
		}
		else {
			return false;
		}
	}

}
