using UnityEngine;
using System.Collections;

public class animation_turnOnTurnOff : MonoBehaviour {

	public static animation_turnOnTurnOff thisOnOff;
//	public static GameObject p1;
//	public static GameObject p2;
	public Animator preAni;
	public Animator atkAni;
	public GameObject[] preObj;
	public GameObject[] atkObj;
	public static bool openPre = true;
	bool reverse = false;
	void OnAwake(){
		thisOnOff = this;
//		p1 = preObj;
//		p2 = atkObj;
	}

	// Use this for initialization
	void Start () {
		//atkAni.SetFloat("speed",0);
		setAbleOrNot (false, atkObj);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void change(){
		print (openPre+" "+preAni.GetFloat("speed")+" "+atkAni.GetFloat("speed"));
		if (openPre) {
			openPre = false;
			atkAni.enabled = true;
			//if(atkAni.GetFloat("speed")==0) atkAni.SetFloat("speed",1);
			setAbleOrNot (true, atkObj);
			setAbleOrNot (false, preObj);
			preAni.SetFloat("speed",0);
		} else {
			openPre = true;
			atkAni.enabled = false;

			setAbleOrNot (false, atkObj);
			setAbleOrNot (true, preObj);

//			atkAni.SetFloat("speed",atkAni.GetFloat("speed")*-1);
			if (preAni.GetFloat ("speed") == 0) {
				if (!reverse) {
					reverse = true;
					preAni.SetFloat("speed",-1);
				} else {
					reverse = false;
					preAni.SetFloat("speed",1);
				}

			} 
		}
	}

	void setAbleOrNot(bool setWhat,GameObject[] objs){
		for (int i = 0; i < objs.Length; i++) {
			objs [i].SetActive (setWhat);
		}
	}
}
