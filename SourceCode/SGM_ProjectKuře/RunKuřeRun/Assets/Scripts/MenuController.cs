using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

	public void PlayGameSingle() {	
		SceneManager.LoadScene(1);
	}
	
	public void PlayGameMulti() {		
		SceneManager.LoadScene(2);
	}

	public void ExitGame() {
		Application.Quit();
	}

	public void Story() {
		SceneManager.LoadScene(4);
	}
}
