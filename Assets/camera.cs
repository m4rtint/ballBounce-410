using UnityEngine;
using System.Collections;

public class camera : MonoBehaviour {
	public Transform ball;
	Vector3 Direction;

	// Use this for initialization
	void Start () {
		Direction = transform.position - ball.transform.position;
	}
	

	void LateUpdate () {
		transform.position = ball.transform.position + Direction;
	}
}
