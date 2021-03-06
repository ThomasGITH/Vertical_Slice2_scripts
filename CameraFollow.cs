﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	// Drag inspector. The target to follow.
	public Transform target;
	public bool clamp;
	public Vector2 clampX, clampY;

	// Speed at which the camera follows the player.
	private float smoothSpeed = 10f;

	// Distance from player to camera.
	[HideInInspector]
	public Vector3 offset = new Vector3(0, 0, -8);

	private void FixedUpdate()
	{
		Follow();
	}

	// Find the target, move towards target.
	void Follow()
	{
		Vector3 desiredPosition = target.position + offset;
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
		if (clamp)
		{
			transform.position = new Vector3(Mathf.Clamp(smoothedPosition.x, clampX.x, clampX.y), Mathf.Clamp(smoothedPosition.y, clampY.x, clampY.y), smoothedPosition.z);
		}
		else
		{
			transform.position = smoothedPosition;
		}
	}
}