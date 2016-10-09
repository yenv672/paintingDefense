using UnityEngine;
using System.Collections;

public class animation_turnOnTurnOff : MonoBehaviour {

	public static animation_turnOnTurnOff thisOnOff;
	public static GameObject p1;
	public static GameObject p2;
	public GameObject preObj;
	public GameObject atkObj;

	void OnAwake(){
		thisOnOff = this;
		p1 = preObj;
		p2 = atkObj;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void change(){
		if (p1.activeSelf) {
			p2.SetActive (true);
			p1.SetActive (false);
		} else {
			p2.SetActive (false);
			p1.SetActive (true);
		}
	}
}
