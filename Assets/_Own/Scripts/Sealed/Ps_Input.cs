using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Ps_Input
{
	const KeyCode Cf_PLAYER_MOVEMENT_FORWARD_KEY = KeyCode.W;
	const KeyCode Cf_PLAYER_MOVEMENT_BACKWARDS_KEY = KeyCode.S;
	const KeyCode Cf_PLAYER_MOVEMENT_RIGHT_KEY = KeyCode.D;
	const KeyCode Cf_PLAYER_MOVEMENT_LEFT_KEY = KeyCode.A;
	const KeyCode Cf_PLAYER_MOVEMENT_JUMP_KEY = KeyCode.Space;
	const KeyCode Cf_PLAYER_MOVEMENT_CROUCH_KEY = KeyCode.C;

	const KeyCode Cf_PLAYER_NEXTITEM_KEY = KeyCode.E;
	const KeyCode Cf_PLAYER_PREVIOUSITEM_KEY = KeyCode.Q;
	const KeyCode Cf_PLAYER_DROPITEM_KEY = KeyCode.R;

	const KeyCode Cf_PLAYER_INTERACTION_KEY = KeyCode.F;
	
	const KeyCode Cf_CAMERA_SHIFT_KEY = KeyCode.Mouse1;


	public static KeyCode GetForwardKey()
	{
		return Cf_PLAYER_MOVEMENT_FORWARD_KEY;
	}


	public static KeyCode GetBackwardsKey()
	{
		return Cf_PLAYER_MOVEMENT_BACKWARDS_KEY;
	}


	public static KeyCode GetRightKey()
	{
		return Cf_PLAYER_MOVEMENT_RIGHT_KEY;
	}


	public static KeyCode GetLeftKey()
	{
		return Cf_PLAYER_MOVEMENT_LEFT_KEY;
	}


	public static KeyCode GetJumpKey()
	{
		return Cf_PLAYER_MOVEMENT_JUMP_KEY;
	}


	public static KeyCode GetCrouchKey()
	{
		return Cf_PLAYER_MOVEMENT_CROUCH_KEY;
	}


	public static KeyCode GetNextItemKey()
	{
		return Cf_PLAYER_NEXTITEM_KEY;
	}


	public static KeyCode GetPreviousItemKey()
	{
		return Cf_PLAYER_PREVIOUSITEM_KEY;
	}


	public static KeyCode GetDropItemKey()
	{
		return Cf_PLAYER_DROPITEM_KEY;
	}


	public static KeyCode GetInteractionKey()
	{
		return Cf_PLAYER_INTERACTION_KEY;
	}


	public static KeyCode GetCameraShiftKey()
	{
		return Cf_CAMERA_SHIFT_KEY;
	}
}
