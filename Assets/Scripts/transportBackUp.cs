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
	int dataIndex = 1;

	//Grabbing Data from dataReader Class
	int incrementOnce = 0;
	dataReader ballScript;
	ArrayList allData = new ArrayList();
	//=====================
	resizeBump bumpScript;

	void Start(){
		ballScript = GameObject.Find ("leftwall").GetComponent<dataReader> ();
		bumpScript = GameObject.Find ("bump").GetComponent<resizeBump> ();
	}

		void OnTriggerEnter2D(Collider2D other)
		{

		//location
		//Get position y of ball.
		endPositionY = transform.position.y;
		Debug.Log ("End Position Y: "+endPositionY);
		//Get Height different between ball and floor
		float height = endPositionY - bottomFloorHeight;
		//Add Height between ball and floor to Y Starting position.
		ballY = startFloorHeight + height;
		//Change Position of ball up
		transform.position = new Vector2 (ballX, ballY);

		//size

		//Grabbing Data - Resizing the ball
		if (dataIndex < allData.Count) 
			{
				string[] testData = (string[])allData [dataIndex];	
				//Debug.Log (testData [0]);
				
				//All this is editable
				//200 lines becomes size 2
				//850 lines becomes 8, 2 sig fig
				scale = int.Parse(testData[0])/100;
				oneScale = Mathf.Round (scale * 1.000f) / 1.000f;
				//Debug.Log(oneScale);
				dataIndex++;

			}

		bumpScript.enterTrigger = true;

		}


	void Update()
	{	
		//Get all Data from dataReader one time
		if(incrementOnce < 10)
		{	
			if(incrementOnce == 9 )
				allData = ballScript.get_data();
			incrementOnce++;
		}
	
				if (transform.localScale.x != scale) {
						if (transform.localScale.x < oneScale) {
								transform.localScale += new Vector3 (0.1f, 0.1f, 0.0f);
			
						} else {
								transform.localScale -= new Vector3 (0.1f, 0.1f, 0.0f);
						}
				}

		}
}
	