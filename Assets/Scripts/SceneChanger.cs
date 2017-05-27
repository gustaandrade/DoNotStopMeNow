using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
	public GameObject fadeout;
	public GameObject canvasInfo;

	public void GoToMenu ()
	{
		SceneManager.LoadScene (1);
	}

	public void FadeOutMenu ()
	{
		fadeout.SetActive (true);
	}

	public void GoToInfo ()
	{
		canvasInfo.SetActive (true);
	}

	public void LeaveInfo ()
	{
		canvasInfo.SetActive (false);
	}

	public void StartGame ()
	{
		SceneManager.LoadScene (2);
	}

	public void QuitGame ()
	{
		Application.Quit ();
	}
}
