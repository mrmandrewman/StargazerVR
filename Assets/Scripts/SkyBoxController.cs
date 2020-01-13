using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoxController : MonoBehaviour
{
	[SerializeField] private float baseRotationSpeed = 1.0f;
	[SerializeField] private float onHighlightSpeedMod = 0.5f;
	[SerializeField] private float speedLerpTime = 1.0f;

	public bool isHighlighted;
	private float currentHighlightLerp = 0.0f;

	private void FixedUpdate()
	{
		if (isHighlighted && currentHighlightLerp < speedLerpTime)
		{
			currentHighlightLerp += Time.deltaTime / speedLerpTime;
			if (currentHighlightLerp >= speedLerpTime)
			{
				currentHighlightLerp = speedLerpTime;
			}
		}
		else if (!isHighlighted && currentHighlightLerp > 0.0f)
		{
			currentHighlightLerp -= Time.deltaTime / speedLerpTime;
			if (currentHighlightLerp < 0)
			{
				currentHighlightLerp = 0;
			}
		}
		float t = currentHighlightLerp / speedLerpTime;
		float currentSpeed = Mathf.Lerp(1.0f, onHighlightSpeedMod, t) * baseRotationSpeed;
		transform.Rotate(transform.up, currentSpeed * Time.deltaTime);

	}

}
