using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

//劃出立體的刷子
public class controller_Painting : MonoBehaviour {

	public static List<GameObject> linePool = new List<GameObject> ();
	public static List<GameObject> DotPool = new List<GameObject>();
	public static controller_Painting thisControllerPainting;
	public static bool ifPaintingReady = false;
	public Transform drawFromHere;
	public GameObject dotPre;
	public GameObject linePre;
	public Renderer[] brushTop;
	public type_info nowType;
	public int createInterval = 15; //creat 1 unit evey "A" frame

	GameObject thisTurnLine = null;
	bool startDrawing = false;
	int count = 0;
	//type_line defaultLineType;

	[System.Serializable]
	public class MyEventType : UnityEvent { }
	public MyEventType startPainting;
	public MyEventType endPainting;

	void Awake(){
		thisControllerPainting = this;
	}
		

	void OnDisable(){
		ifPaintingReady = false;
	}


	// Use this for initialization
	void Start () {
		//1defaultLineType = nowLineType;
		nowType = type_general.thisGeneral.colorSetting[0];
		changeColor ();
		ifPaintingReady = true;
	}

	public void changeColor(){
		for (int i = 0; i < brushTop.Length; i++) {
			brushTop [i].material = nowType.myMat;
		}
	}
	
	public void Drawing(){
		if (!startDrawing) {
			count = 1;
			startDrawing = true;
			lineInit ();
		} else {
			count += 1;
			if (count % createInterval == 0) {
				lineBuilding ();
			}
			startPainting.Invoke ();
		}

	}

	public void EndDrawing(){
		if (startDrawing) {
//			thisTurnLine.GetComponent<type_line> ().donePainting = true;
			thisTurnLine = null;
			count = 0;
			startDrawing = false;
			endPainting.Invoke ();
		}
	}

	void lineInit(){
		GameObject thisLine = find (linePool);
		if (thisLine == null) {
			thisLine = Instantiate (linePre, drawFromHere.transform.position, Quaternion.identity) as GameObject;
			thisLine.name = "line " + linePool.Count;

		} else {
			thisLine.transform.position = drawFromHere.transform.position;
		}
		thisTurnLine = thisLine;
		thisTurnLine.SetActive (true);
		if(!linePool.Contains(thisLine))linePool.Add (thisLine);
	}

	void lineBuilding(){
		GameObject thisDot = find(DotPool);
		if (thisDot == null) {
			thisDot = Instantiate (dotPre, drawFromHere.transform.position, Quaternion.identity,thisTurnLine.transform) as GameObject;
			thisDot.name = "dot " + DotPool.Count;

		} else {
			thisDot.transform.position = drawFromHere.transform.position;
		}
		thisDot.transform.SetParent (thisTurnLine.transform);
		thisDot.GetComponent<type_dot>().myType = nowType.mytype;
		thisDot.GetComponent<Renderer> ().material = nowType.myMat;
		thisDot.SetActive (true);
		thisTurnLine.GetComponent<type_line> ().dots.Add (thisDot);
		if(!DotPool.Contains(thisDot))DotPool.Add (thisDot);
	}

	GameObject find(List<GameObject> list){
		foreach (GameObject item in list) {
			if (!item.activeSelf)
				return item;
		}	
		return null;
	}
}
