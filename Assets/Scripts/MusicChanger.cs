using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicChanger : MonoBehaviour
{
	public Image icon;
	public Sprite soundon;
	public Sprite soundoff;
	private AudioSource music;

	void Start ()
	{
		music = GetComponent<AudioSource> ();
	}

	public void ChangeSound ()
	{
		if (!music.mute) {
			music.mute = true;
			icon.sprite = soundoff;
		} else {
			music.mute = false;
			icon.sprite = soundon;
		}
	}
}
