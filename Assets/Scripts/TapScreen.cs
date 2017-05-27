using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript.Gestures;

public class TapScreen : MonoBehaviour
{
	private TapGesture gesture;
	public 	PlayerController pc;

	public void Awake ()
	{
		gesture = GetComponent<TapGesture> ();
	}

	public void TapHandler (object sender, System.EventArgs e)
	{ // função que o touchscript executa para decidir o que fazer com o toque
		pc.Jump ();
	}

	public void OnEnable ()
	{
		gesture.Tapped += TapHandler; 	// a linha salva a função de tratamento do toque taphandler dentro do delegate (tapped)
	}

	public void OnDisable ()
	{
		gesture.Tapped -= TapHandler;
	}
}