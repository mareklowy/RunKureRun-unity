using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public int _playerWinnerNO;
	
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this);
	}

	public void PlayerWon(int playerNO) {
		_playerWinnerNO = playerNO;
	}
	
}
