using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour {

	public int poolSize = 10;

	public PoolItem poolObject;

	private List<PoolItem> m_Pool = new List<PoolItem>();

	private void Start() {
		for(int i = 0; i < poolSize; i++) {
			CreateNewItem();
		}
	}

	public static Pool NewPool(PoolItem item) {
		if (!item) {
			Debug.LogError("no pool item");
			return null;
		}
		GameObject newpool = new GameObject($"Pool_{item.name}");
		Pool pool = newpool.AddComponent<Pool>();
		pool.poolObject = item;
		return pool;
	}

	public void CreateNewItem() {
		PoolItem item = Instantiate(poolObject, transform);
		item.SetPool(this);
		m_Pool.Add(item);
	}

	public PoolItem GetItem() {
		if (m_Pool.Count == 0) {
			CreateNewItem();
		}
		PoolItem item = m_Pool[0];
		m_Pool.RemoveAt(0);
		return item;
	}

	public void ReturnToPool(PoolItem item) {
		if (!m_Pool.Contains(item)) {
			m_Pool.Add(item);
		}
	}
}
