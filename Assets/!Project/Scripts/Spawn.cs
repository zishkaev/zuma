using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {
	[SerializeField] private PathCreator pathCreator;
	[SerializeField] private Pool pool;
	[SerializeField] private float speed;
	[SerializeField] private float delaySpawn;
	private Ball ball;
	private float t;

	private void Update() {
		if (t > delaySpawn) {
			CreateNewBall();
			t = 0;
		}
		t += Time.deltaTime;
	}

	private void CreateNewBall() {
		PoolItem item = pool.GetItem();
		ball = item.GetComponent<Ball>();
		ball.Init(BallState.chain);
		ball.SetMover(pathCreator, 0, speed);
		ball.gameObject.SetActive(true);
	}
}
