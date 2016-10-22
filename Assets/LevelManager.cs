using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name) {
		Debug.Log("LoadLevel: name=" + name);
		SceneManager.LoadScene(name);
	}

	public void QuitGame() {
		Debug.Log("Quit Game requested");
		Application.Quit();
	}
}
