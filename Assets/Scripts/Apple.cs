﻿using UnityEngine;
using System.Collections;

public class Apple : MonoBehaviour {
	public static float bottomY = -20f;

	// Update is called once per frame
	void Update () {
		if (transform.position.y < bottomY) {
			Destroy (this.gameObject);

			//Get reference to ApplePicker component of Main Camera
			ApplePicker apScript = Camera.main.GetComponent<ApplePicker> (); //1
			//Call public AppleDestroyed() method of apScript
			apScript.AppleDestroyed (); //2
		}
	}
}