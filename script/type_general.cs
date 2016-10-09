using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class type_general : MonoBehaviour {

	public static type_general thisGeneral;
	public List<type_info> colorSetting = new List<type_info> ();

	void Awake(){
		thisGeneral = this;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public Material findMat(type t){
		foreach (type_info a in colorSetting) {
			if (a.mytype == t)
				return a.myMat;
		}
		return null;
	}

	public type_info findInfo(type t){
		foreach (type_info a in colorSetting) {
			if (a.mytype == t)
				return a;
		}
		return null;
	}
}



public enum type
{
	red=0,yellow=1,blue=2
}

[System.Serializable]
public class type_info{
	public type mytype;
	public Material myMat;
	public type_info(type nType,Material nMat){
		mytype = nType;
		myMat = nMat;
	}
}