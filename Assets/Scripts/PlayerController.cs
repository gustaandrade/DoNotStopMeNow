using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	private Rigidbody2D body;
	private CircleCollider2D circle;

	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool grounded;
	private bool doubleJumped;

	private Animator anim;

	public Sprite broken;

	public GameObject tuto1;
	public GameObject tuto2;
	public GameObject tuto3;
	public GameObject tuto4;

	private float speed;

	public Text planta;
	private int numplanta;

	void Start ()
	{
		body = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		circle = GetComponent<CircleCollider2D> ();
		speed = 2F;
		numplanta = 0;
	}

	void FixedUpdate ()
	{
		Move ();

		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);

		if (body.velocity.y == 0) {
			anim.SetBool ("isJumping", false);
		}
	}

	public void Move ()
	{
		body.velocity = new Vector2 (speed * GameConstants.PLAYER_SPEED, body.velocity.y);
	}

	public void Jump ()
	{
		anim.SetBool ("isJumping", true);

		if (grounded) {
			doubleJumped = false;
			body.velocity = new Vector2 (body.velocity.x, GameConstants.PLAYER_JUMP_FORCE);
		}
		if (!doubleJumped && !grounded) {
			body.velocity = new Vector2 (body.velocity.x, GameConstants.PLAYER_JUMP_FORCE);
			doubleJumped = true;
		}
	}

	public void Duck ()
	{
		circle.radius = GameConstants.PLAYER_RADIUS_DUCKING;
		anim.SetBool ("isDucking", true);
	}

	public void Attack ()
	{
		anim.SetBool ("isAttacking", true);
	}

	public void SetBoolDuckFalse ()
	{
		circle.radius = GameConstants.PLAYER_RADIUS;
		anim.SetBool ("isDucking", false);
	}

	public void SetBoolAttackFalse ()
	{
		anim.SetBool ("isAttacking", false);
	}

	public void ReloadLevel ()
	{
		SceneManager.LoadScene (2);
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.CompareTag (GameConstants.FENCE_TAG) && anim.GetCurrentAnimatorStateInfo (0).IsName ("anim_player_attack")) {
			col.collider.enabled = false;
			col.gameObject.GetComponent<SpriteRenderer> ().sprite = broken;
		}

		if (col.gameObject.CompareTag (GameConstants.ENEMY_TAG)) {
			anim.SetBool ("isDying", true);
		}

		if (col.gameObject.CompareTag (GameConstants.FAST_TAG)) {
			speed = GameConstants.PLAYER_FAST_SPEED;
		}

		if (col.gameObject.CompareTag (GameConstants.SLOW_TAG)) {
			speed = GameConstants.PLAYER_SLOW_SPEED;
		}

		if (col.gameObject.CompareTag (GameConstants.ENDING_TAG)) {
			if (numplanta == GameConstants.NUM_COLLECTIBLES)
				SceneManager.LoadScene (0);
			else
				SceneManager.LoadScene (2);
		}
	}

	void OnCollisionExit2D (Collision2D col)
	{
		if (col.gameObject.CompareTag (GameConstants.FAST_TAG)) {
			speed = GameConstants.PLAYER_SPEED;
		}

		if (col.gameObject.CompareTag (GameConstants.SLOW_TAG)) {
			speed = GameConstants.PLAYER_NORMAL_SPEED;
		}
	}

	void OnTriggerEnter2D (Collider2D trig)
	{
		if (trig.gameObject.CompareTag (GameConstants.COLLECTIBLE_TAG)) {
			trig.gameObject.SetActive (false);
			numplanta++;
			planta.text = numplanta.ToString ();
		}
	}

	void OnBecameVisible ()
	{
		enabled = true;
	}

	void OnBecameInvisible ()
	{
		enabled = false;
	}
}
	
