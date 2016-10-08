using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

//劃出立體的刷子
public class controller_Painting : MonoBehaviour {

	public static List<GameObject> linePool = new List<GameObject>();
	public static controller_Painting thisControllerPainting;
	public static bool ifPaintingready = false;
	public static int leftPaint;
	public Transform drawFromHere;
	public GameObject paintSingleUnit;
	public int createInterval = 15; //creat 1 unit evey "A" frame


	levelInfo thisLevel;
	playerInfo thisPlayerInfo;
	bool startDrawing = false;
	int count = 0;
	LineRenderer thisTurnLineRenderer;
	type_line thisLineStatus;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
