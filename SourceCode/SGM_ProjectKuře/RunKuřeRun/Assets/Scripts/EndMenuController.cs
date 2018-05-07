using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndMenuController : MonoBehaviour {

	[SerializeField] private TextMeshProUGUI _text;
	private GameManager _gameManager;

	private void Start() {
		_gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
		_text.text = "player " + _gameManager._playerWinnerNO + " won!!!";
	}

	public void MainMenu() {
		SceneManager.LoadScene(0);
	}
	
	public void ExitGame() {
		Application.Quit();
	}
}
