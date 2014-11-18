using UnityEngine;
using System.Collections;

public class ball_trigger_cs : MonoBehaviour {

	public static bool inAirInd;	
	public counter_cs counter;

	void OnCollisionEnter2D(Collision2D  col){

		if (col.gameObject.tag == "EditorOnly") {
			//Debug.Log("hit the floor");  
			inAirInd = false;
			Debug.Log (inAirInd);
			//counter.inAir = inAirInd;
		}
	}

	void OnCollisionExit2D(Collision2D  col){
		
		if (col.gameObject.tag == "EditorOnly") {
			Debug.Log("in air");  
			inAirInd = true;
			Debug.Log (inAirInd);
			//counter.inAir = inAirInd;
		}
	}
}