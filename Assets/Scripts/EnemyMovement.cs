using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
	public float delta = 3f;
	public float speed = 2.0f;
	private Vector3 startPos;
	private Transform trans;

	void Start ()
	{
		trans = GetComponent<Transform> ();
		startPos = trans.position;
	}

	void Update ()
	{
		Vector3 v = startPos;
		v.x += delta * Mathf.Sin (Time.time * speed);
		trans.position = v;
	}
}
