using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
	public static InputSystem instance;

	public Action<bool> onShoot;
	public Action onPause;

	private Vector3 mousePosition;

	private void Awake() {
		instance = this;
	}

	private void Update() {
		//mouse
		mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		//shoot
		if (Input.GetKeyDown(KeyCode.Mouse0)) {
			onShoot?.Invoke(true);
		}
		//pause
		if (Input.GetKeyDown(KeyCode.Escape)) {
			onPause?.Invoke();
		}
	}

	public Vector3 GetMouse() {
		return mousePosition;
	}
}
