using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

	public Transform player;
	public Transform camera;

	// Update is called once per frame
	void Update()
	{
		Vector3 offset = new Vector3(0f, 1.81f, -2.02f);
		camera.position = player.position + offset;
		var cameraRotation = camera.rotation;
		cameraRotation.y = player.rotation.y - 178.987f;
	}
}
