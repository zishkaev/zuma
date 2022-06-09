using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove : Move {
	protected override void Moving() {
		transform.position += transform.forward * speed * Time.deltaTime;
	}
}
