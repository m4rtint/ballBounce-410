using UnityEngine;
using System.Collections;

public class updateSize : MonoBehaviour {

	float scale;
	
	void OnTriggerEnter2D(Collider2D other)
	{
		scale = Random.Range (0.1f, 1.0f);
		Debug.Log ("Object entered the trigger");

		transform.localScale = new Vector3(scale,scale,1.0f);
	}
	
}
