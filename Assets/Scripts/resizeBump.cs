using UnityEngine;
using System.Collections;

public class resizeBump : MonoBehaviour {

	public bool enterTrigger;
	float scale ;
	float oneScale;
	int dataIndex = 1;

	//Grabbing Data from dataReader Class
	int incrementOnce = 0;
	dataReader ballScript;
	ArrayList allData = new ArrayList();
	//=====================

	void Start () {
		ballScript = GameObject.Find ("leftwall").GetComponent<dataReader> ();
		enterTrigger = false;
	}
	
	// Update is called once per frame
	void Update () {
		//Get all Data from dataReader one time
		if(incrementOnce < 10)
		{	
			if(incrementOnce == 9 )
				allData = ballScript.get_data();
			incrementOnce++;
		}

		if (enterTrigger) 
		{
			//size
			
			//Grabbing Data - Resizing the ball
			if (dataIndex < allData.Count) 
			{
				string[] testData = (string[])allData [dataIndex];	
				//Debug.Log (testData [0]);
				
				//All this is editable
				//testData[2] = Number of error flags in total
				//200 lines becomes size 2
				//850 lines becomes 8, 2 sig fig
				scale = int.Parse(testData[2])/10;
				oneScale = Mathf.Round (scale * 1.000f) / 1.000f;
				Debug.Log(oneScale);
				dataIndex++;
				
			}
			transform.localScale = new Vector3 (oneScale, oneScale, 1.0f);
			enterTrigger=false;

		}

	}
}
