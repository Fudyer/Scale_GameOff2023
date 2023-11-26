using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointFlashlight : MonoBehaviour
{
	private Transform armBone;

	private void Start()
	{
		armBone = GetComponentInChildren<Animator>().GetBoneTransform(HumanBodyBones.RightUpperArm);
	}

	private void Update()
	{
		// Rotate the arm bone to point forward.
		float angle = 45.0f; // Adjust the angle as needed.
		armBone.rotation = Quaternion.Euler(0, angle, 0);
	}
}
