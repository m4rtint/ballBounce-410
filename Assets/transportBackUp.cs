using UnityEngine;
using System.Collections;

public class transportBackUp : MonoBehaviour {
	float endPositionY;
	float ballX = 43.2f;
	float ballY;
	public static float bottomFloorHeight = -18.4f;
	public static float startFloorHeight = 19.6f;
	float scale = 5.0f;
	double oneScale;
	void OnTriggerEnter2D(Collider2D other)
	{

		//location
		//Get position y of ball.
		endPositionY = transform.position.y;
		Debug.Log (endPositionY);
		//Get Height different between ball and floor
		float height = endPositionY - bottomFloorHeight;
		//Add Height between ball and floor to Y Starting position.
		ballY = startFloorHeight + height;
		//Change Position of ball up
		transform.position = new Vector2 (ballX, ballY);

		//size
		scale = Random.Range (5.0f, 25.0f);
		oneScale = Mathf.Round (scale * 1.000f)/1.000f ;
	}

	/*void colourMesh(int n){
		var mesh : Mesh = GetComponent(MeshFilter).mesh;
		var vertices : Vector3[] = mesh.vertices;
		var colors : Color[] = new Color[vertices.Length];

		for (var i = 0; i < vertices.Length;i++)
			colors[i] = Color.Lerp(Color.red, Color.green, vertices[i].y);

		mesh.colors = colors;
	}
	*/

		
	//hill is a full circle, make it into half, and partiition it
		
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
	