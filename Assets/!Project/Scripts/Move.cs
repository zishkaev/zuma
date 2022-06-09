using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
	[SerializeField] protected float speed;
	private bool isMove;
	public float Speed => speed;

	private void Update() {
		if (!isMove) return;
			Moving();
	}

	protected virtual void Moving() { }

	public void SetMove(bool state) {
		isMove = state;
	}

	public void SetSpeed(float speed) {
		this.speed = speed; 
	}
}
