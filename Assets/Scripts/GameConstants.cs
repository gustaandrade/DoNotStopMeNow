using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConstants : MonoBehaviour
{
	// Tags
	public const string PLAYER_TAG = "Player";
	public const string ENEMY_TAG = "Enemy";
	public const string FENCE_TAG = "Fence";
	public const string PORTAL_TAG = "Portal";
	public const string SLOW_TAG = "Slow";
	public const string FAST_TAG = "Fast";
	public const string ENDING_TAG = "Ending";
	public const string COLLECTIBLE_TAG = "Coletavel";

	// Values
	public const float PLAYER_SPEED = 3.5F;
	public const float PLAYER_JUMP_FORCE = 7F;
	public const float PLAYER_RADIUS = 0.24F;
	public const float PLAYER_RADIUS_DUCKING = 0.1F;
	public const float PLAYER_SLOW_SPEED = 1.5F;
	public const float PLAYER_FAST_SPEED = 2.5F;
	public const float PLAYER_NORMAL_SPEED = 2F;
	public const float NUM_COLLECTIBLES = 13;
}
