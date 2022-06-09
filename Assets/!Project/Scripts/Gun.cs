using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
	[SerializeField] private Transform muzzle;
	[SerializeField] private Transform ballPoint;
	[SerializeField] private Pool pool;
	private Ball ball;


	private void Awake() {
		InputSystem.instance.onShoot += Shoot;
	}

	private void Start() {
		CreateNewBall();
	}

	public void Shoot(bool state) {
		ball.transform.position = muzzle.position;
		ball.transform.rotation = muzzle.rotation;
		ball.StartMove();
		CreateNewBall();
	}

	public void CreateNewBall() {
		PoolItem item = pool.GetItem();
		ball = item.GetComponent<Ball>();
		ball.Init(BallState.free);
		ball.transform.position = ballPoint.position;
		ball.gameObject.SetActive(true);
	}

	private void OnDestroy() {
		InputSystem.instance.onShoot -= Shoot;
	}
}
