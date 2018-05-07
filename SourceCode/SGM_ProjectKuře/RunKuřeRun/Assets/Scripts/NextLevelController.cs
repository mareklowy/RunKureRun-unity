using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelController : MonoBehaviour {

	private GameManager _gameManager;

	private void Start() {
		_gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
	}

	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Player")) {
			int playerWon = other.gameObject.GetComponent<PlayerControls>()._playerNO;
			_gameManager.PlayerWon(playerWon);
			print("End");
			SceneManager.LoadScene(3);
			//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
			//in current build index, next level will always be 2 spaces forward
		}
	}
}
