using UnityEngine;
using System.Collections;

public class resizeBump : MonoBehaviour {

	public bool enterTrigger;
	// Use this for initialization
	void Start () {
		enterTrigger = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (enterTrigger) {
			Debug.Log ("I can change it now");
			//Change stuff here
			transform.localScale = new Vector3 (Random.Range (5.0f, 25.0f), Random.Range (5.0f, 25.0f), 0.0f);
			enterTrigger=false;

				}

	}
}
