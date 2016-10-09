using UnityEngine;
using System.Collections;

public class animation_turnOnTurnOff : MonoBehaviour {

	public static animation_turnOnTurnOff thisOnOff;
	public GameObject preObj;
	public GameObject atkObj;

	void OnAwake(){
		thisOnOff = this;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
