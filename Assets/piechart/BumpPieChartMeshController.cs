﻿using UnityEngine;
using System.Collections;

public class BumpPieChartMeshController : MonoBehaviour
{
	BumpPieChartMesh mPieChart;
	float[] mData;
	int dataIndex=0;
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
		mPieChart = gameObject.AddComponent("BumpPieChartMesh") as BumpPieChartMesh;
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
		if (incrementOnce < 8)
		{
			if (incrementOnce == 7)
			{
				//Grab Data
				//Set PieChart of initial state instantly.
				allData = ballScript.get_data ();
				string[] testData = (string[])allData[dataIndex];
				Debug.Log (testData[3]);
				mData = getDataFromString(testData[3]);
				dataIndex++;
				mPieChart.Draw(mData);
			}
			incrementOnce++;
		}
		
		if (enterTrigger) 
		{
			if(dataIndex <allData.Count)
			{
				//Update the BumpChart Each time enter the trigger
				//Grabbing the string data an send it to method getDatafromString
				string[] testData = (string[])allData[dataIndex];
				mData = getDataFromString(testData[3]);
				dataIndex++;
				mPieChart.Draw(mData);
			}
			enterTrigger=false;
		}
	}


	//Grab String, split into array of float
	//returns the float[] array
	float[] getDataFromString(string data)
	{
		string[] stringTargets = data.Split(',');
		float[] targets = new float[int.Parse (stringTargets[0])];
		// length-1 because need to ignore the number 
		// of people in the first element of array
		for (int x = 0; x < stringTargets.Length-1; x++) 
		{
			//x+1 data extracted is 
			//number of people,line,line,line.
			//e.g. 5,10,100,20,30,20 so 5 would be number of people
			//all numbers followed are the lines of code by each person
			targets[x] = int.Parse(stringTargets[x+1]);
		//	Debug.Log(targets[x]);
		}
		
		return targets;
	}
}
