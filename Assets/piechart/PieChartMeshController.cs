using UnityEngine;
using System.Collections;

public class PieChartMeshController : MonoBehaviour
{
    PieChartMesh mPieChart;
    float[] mData;
	int dataIndex=1;
	//PieChart Update variable
	public bool enterTrigger;


	//Grabbing Data from dataReader Class
	int incrementOnce = 0;
	dataReader ballScript;
	ArrayList allData = new ArrayList();
	//=====================

    void Start()
    {
		//Get Data from dataReader
		ballScript = GameObject.Find ("leftwall").GetComponent<dataReader> ();
		//========
        mPieChart = gameObject.AddComponent("PieChartMesh") as PieChartMesh;
        if (mPieChart != null)
        {
            mPieChart.Init(mData, 10, 0, 10, null);
			mData = initialArray();
            mPieChart.Draw(mData);
        }

		//SetTrigger as false so it doesn't update at the start
		enterTrigger=false;

    }

	//Initial Piechart at the original start state
	float[] initialArray()
	{
		float [] start = new float[1];
		start [0] = 1;
		return start;
	}


    void Update()
    {
		//Get all Data from the data Reader one time
        if (incrementOnce < 2)
		{
			if (incrementOnce == 1)
			{	
				//Grab Data
				//Set PieChart of initial state instantly.
				allData = ballScript.get_data ();
				string[] testData = (string[])allData[dataIndex];
				mData = getDataFromString(testData[1]);
				dataIndex++;
				mPieChart.Draw(mData);
			}
			incrementOnce++;
		}

		if (enterTrigger) 
		{
			//Update piechart whenever enter trigger zone
			//Stop updating when reach end of array = no more data
			if(dataIndex <allData.Count)
			{
			string[] testData = (string[])allData[dataIndex];
			mData = getDataFromString(testData[1]);
			dataIndex++;
			mPieChart.Draw(mData);
			}
			enterTrigger=false;
		}
    }

	//Get string of data - 1,2,3,4
	//Split into array of float
	//returns array of float
    float[] getDataFromString(string data)
    {
		string[] stringTargets = data.Split(',');
		float[] targets = new float[10];
		// length-1 because need to ignore the number 
		// of people in the first element of array
		for (int x = 0; x < stringTargets.Length-1; x++) 
		{
			//x+1 data extracted is 
			//number of people,line,line,line.
			//e.g. 5,10,100,20,30,20 so 5 would be number of people
			//all numbers followed are the lines of code by each person
			targets[x] = int.Parse(stringTargets[x+1]);
//			Debug.Log(targets[x]);
		}

        return targets;
    }
}
