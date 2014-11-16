using UnityEngine;
using System.Collections;

public class counter_cs : MonoBehaviour {
	private float Counter = 0;
	public static bool inAir;
	string history="\nAir Time History";
	int interval=1;

	void Start(){
		guiText.text = "Air Time :" + Counter + " s" + history;
		}
	// Update is called once per frame
	void Update () {
		inAir = ball_trigger_cs.inAirInd;
		if(inAir){
			Counter += Time.deltaTime;
			Debug.Log (Counter);
			guiText.text = "Air Time :" + Counter+" s"+history;
		}else{
			if(Counter>0.1)
			{
			history = history+"\n"+interval+". "+Counter;
			guiText.text = "Air Time :" + Counter+" s"+history;
			interval++;
			}

			Counter = 0;
		}
		//Debug.Log (Counter);
	}
}
