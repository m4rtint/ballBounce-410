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
	PieChartMeshController pieChartScript;
	BumpPieChartMeshController BumpChartScript;

	void Start(){
		ballScript = GameObject.Find ("leftwall").GetComponent<dataReader> ();
		bumpScript = GameObject.Find ("bump").GetComponent<resizeBump> ();
		pieChartScript = GameObject.Find ("ball").GetComponent<PieChartMeshController> ();
		BumpChartScript = GameObject.Find ("bump").GetComponent<BumpPieChartMeshController> ();
	}

		void OnTriggerEnter2D(Collider2D other)
		{

		//location
		//Get position y of ball.
		endPositionY = transform.position.y;
//		Debug.Log ("End Position Y: "+endPositionY);
		//Get Height different between ball and floor
		float height = endPositionY - bottomFloorHeight;
		//Add Height between ball and floor to Y Starting position.
		ballY = startFloorHeight + height;
		//Change Position of ball up
		transform.position = new Vector2 (ballX, ballY);
		transform.position = new Vector2 (87.98248f,41.29656f);

		//Test out if velocity zeroes out
		//rigidbody2D.velocity = Vector3.zero;
		rigidbody2D.angularVelocity = 0;

		rigidbody2D.velocity = Vector2.zero;
		//size

		//Grabbing Data - Resizing the ball
		if (dataIndex < allData.Count) 
			{
				string[] testData = (string[])allData [dataIndex];	
				//Debug.Log (testData [0]);
				
				//All this is editable
				//200 lines becomes size 2
				//850 lines becomes 8, 2 sig fig
			scale = Mathf.Sqrt(Mathf.Sqrt(int.Parse(testData[0])));
				oneScale = Mathf.Round (scale * 10.0f) / 10.0f;
				//Debug.Log(oneScale);
				dataIndex++;

			}

		bumpScript.enterTrigger = true;
		pieChartScript.enterTrigger = true;
		BumpChartScript.enterTrigger = true;

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
	