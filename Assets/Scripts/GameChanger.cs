using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameChanger : MonoBehaviour
{
	public GameObject canvas;
	private bool isPaused = false;

	public void PauseGame ()
	{
		if (!isPaused) {
			canvas.SetActive (true);
			isPaused = true;
			Time.timeScale = 0;
		} else {
			canvas.SetActive (false);
			isPaused = false;
			Time.timeScale = 1;
		}
	}

	public void GoToMenu ()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene (0);
	}
}
