using UnityEngine;
using System.Collections;

public class controller_ChangeColor : MonoBehaviour {

	public controller_Painting myPaint;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ChangeToYellow(){
		myPaint.nowType = type_general.thisGeneral.findInfo (type.yellow);
		myPaint.changeColor ();
	}

	public void ChangeToRed(){
//		print ("here");
		myPaint.nowType = type_general.thisGeneral.findInfo (type.red);
		myPaint.changeColor ();
	}

	public void ChangeToBlue(){
		myPaint.nowType = type_general.thisGeneral.findInfo (type.blue);
		myPaint.changeColor ();
	}
}
