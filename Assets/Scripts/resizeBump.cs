using UnityEngine;
using System.Collections;

public class resizeBump : MonoBehaviour {

	public bool enterTrigger;
	float scale ;
	// Use this for initialization
	void Start () {
		enterTrigger = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (enterTrigger) {
			Debug.Log ("I can change it now");
			//Change stuff here
			scale = Random.Range(5.0f,25.0f);
			transform.localScale = new Vector3 (scale, scale, 1.0f);
			enterTrigger=false;

				}

	}
}
