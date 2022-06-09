using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveMove : Move {
	[SerializeField] private PathCreator pathCreator;
	[SerializeField] private EndOfPathInstruction endOfPathInstruction;
	[SerializeField] private float distanceTravelled;

	public PathCreator Path => pathCreator;
	public float Distance => distanceTravelled;

	private void Start() {
		endOfPathInstruction = EndOfPathInstruction.Stop;
		if (pathCreator != null) {
			pathCreator.pathUpdated += OnPathChanged;
		}
	}

	public void SetPath(PathCreator creator) {
		pathCreator = creator;
	}

	public void SetDistance(float distance) {
		distanceTravelled = distance;
	}

	protected override void Moving() {
		if (pathCreator != null) {
			distanceTravelled += speed * Time.deltaTime;
			transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
			transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
		}
	}

	private void OnPathChanged() {
		distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
	}

	private void OnDestroy() {
		if (pathCreator != null) {
			pathCreator.pathUpdated -= OnPathChanged;
		}
	}
}
