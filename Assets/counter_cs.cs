using UnityEngine;
using System.Collections;

public class counter_cs : MonoBehaviour {
	private float Counter = 0;
	public static bool inAir;
	// Update is called once per frame
	void Update () {
		inAir = ball_trigger_cs.inAirInd;
		if(inAir){
			Counter += Time.deltaTime;
			Debug.Log (Counter);
			guiText.text = "Flytime :" + Counter;
		}else{
			Counter = 0;
		}
		//Debug.Log (Counter);
	}
}
