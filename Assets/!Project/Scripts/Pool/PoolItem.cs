using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolItem : MonoBehaviour {
	private Pool pool;

	//private void Start() {
	//	GameController.instance.onEndGame += ReturnToPool;
	//}

	private void OnEnable() {
		transform.parent = null;
	}

	public void SetPool(Pool pool) {
		this.pool = pool;
		transform.parent = pool.transform;
		gameObject.SetActive(false);
	}

	public void ReturnToPool() {
		if (pool)
			pool.ReturnToPool(this);
		transform.parent = pool.transform;
		gameObject.SetActive(false);
	}

	//private void OnDestroy() {
	//	GameController.instance.onEndGame -= ReturnToPool;
	//}
}
