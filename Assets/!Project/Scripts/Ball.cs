using PathCreation;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
	[SerializeField] private BallState ballState;
	[SerializeField] private ColorType ballType;
	[SerializeField] private Move move;
	[SerializeField] private float radius;
	public ColorType Type => ballType;

	private Material material;
	private Ball forward;
	private Ball back;
	private bool isLast;
	private bool isDead;

	private Action onExplosion;
	public bool IsDead => isDead;

	public void Init(BallState state) {
		ballState = state;
		material = GetComponentInChildren<Renderer>().material;
		ballType = (ColorType)UnityEngine.Random.Range(0, (int)ColorType.e_count);
		SetColor();
	}

	private void OnCollisionEnter(Collision collision) {
		if (ballState == BallState.chain) return;
		Ball ball = collision.collider.GetComponentInParent<Ball>();
		if (ball) {
			ballState = BallState.chain;
			back = ball;
			ChangeMover(ball);
			ball.SetForwardBall(this);
		}
	}

	private void SetColor() {
		switch (ballType) {
			case ColorType.white:
				material.color = Color.white;
				break;
			case ColorType.yellow:
				material.color = Color.yellow;
				break;
			case ColorType.red:
				material.color = Color.red;
				break;
			case ColorType.green:
				material.color = Color.green;
				break;
			case ColorType.blue:
				material.color = Color.blue;
				break;
			case ColorType.black:
				material.color = Color.black;
				break;
		}
	}

	public void SetBackBall(Ball ball) {
		if (back) {
			back.onExplosion -= NearBallExplosion;
		}
		if (isLast)
			isLast = false;
		back = ball;
		UpdateMover(ball);
		StartMove();
	}

	public void SetForwardBall(Ball ball) {
		if (forward) {
			forward.onExplosion -= NearBallExplosion;
			ball.SetForwardBall(forward);
		}
		forward = ball;
	}

	public void NearBallExplosion() {
		if (back == null || back.IsDead) {
			StopMove();
		}
	}

	public void SetLast() {
		isLast = true;
	}

	public void StartMove() {
		move.SetMove(true);
	}

	public void ChangeMover(Ball ball) {
		CurveMove curveMoveFromBall = (CurveMove)ball.move;
		SetMover(curveMoveFromBall.Path, curveMoveFromBall.Distance + radius * 2, curveMoveFromBall.Speed);
	}

	public void SetMover(PathCreator path, float distance, float speed) {
		StopMove();
		Destroy(move);
		CurveMove curveMove = gameObject.AddComponent<CurveMove>();
		curveMove.SetPath(path);
		curveMove.SetSpeed(speed);
		curveMove.SetDistance(distance);
		move = curveMove;
		StartMove();
	}

	public void UpdateMover(Ball ball) {
		CurveMove curveMoveFromBall = (CurveMove)ball.move;
		CurveMove curveMove = (CurveMove)move;
		curveMove.SetDistance(curveMoveFromBall.Distance);
	}

	public Move GetMover() {
		return move;
	}

	public void StopMove() {
		move.SetMove(false);
	}

	public void CheckType() {
		if (forward.Type == Type && back.Type == Type) {

		} else {

		}
	}

	private void OnDestroy() {
		isDead = true;
		onExplosion?.Invoke();
	}
}
