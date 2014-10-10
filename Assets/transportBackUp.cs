using UnityEngine;
using System.Collections;

public class transportBackUp : MonoBehaviour {
	float originalY;
	float ballX = 43.2f;
	float ballY;

	float scale = 5.0f;
	double oneScale;
		void OnTriggerEnter2D(Collider2D other)
		{

		//location
		originalY = transform.position.y;
		Debug.Log (originalY);
		float height = originalY + 7.03f;
		ballY = 18.9f + height;
		transform.position = new Vector2 (ballX, ballY);

		//size
		scale = Random.Range (5.0f, 25.0f);
		oneScale = Mathf.Round (scale * 1.000f)/1.000f ;




		}

	void Update(){
				if (transform.localScale.x != scale) {
						if (transform.localScale.x < oneScale) {
								transform.localScale += new Vector3 (0.1f, 0.1f, 0.0f);
			
						} else {
								transform.localScale -= new Vector3 (0.1f, 0.1f, 0.0f);
						}
				}

		}
}
	