using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour {
	private Vector3 mousePosition;

	void Update() {
		mousePosition = InputSystem.instance.GetMouse();
		mousePosition.y = transform.position.y;
		transform.LookAt(mousePosition);
	}
}
