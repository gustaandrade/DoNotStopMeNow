using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript.Gestures;

public class FlickScreen : MonoBehaviour
{
	private FlickGesture gesture;
	public 	PlayerController pc;

	public void Awake ()
	{
		gesture = GetComponent<FlickGesture> ();
	}

	public void FlickHandler (object sender, System.EventArgs e)
	{ // função que o touchscript executa para decidir o que fazer com o flick
		if (gesture.ScreenFlickVector.x > 200) {
			pc.Attack ();
		} else if (gesture.ScreenFlickVector.y < -100) {
			pc.Duck ();
		}
	}

	public void OnEnable ()
	{
		gesture.Flicked += FlickHandler; 	// a linha salva a função de tratamento do toque taphandler dentro do delegate (tapped)
	}

	public void OnDisable ()
	{
		gesture.Flicked -= FlickHandler;
	}
}