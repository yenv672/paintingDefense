﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class type_line : MonoBehaviour {

	public List<GameObject> dots = new List<GameObject> ();
//	public bool donePainting = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Die(){
//		print ("here DIE");
		foreach (GameObject obj in dots) {
			obj.SetActive (false);
			obj.transform.SetParent (null);
		}
		dots.Clear ();
		gameObject.SetActive (false);
	}
}
