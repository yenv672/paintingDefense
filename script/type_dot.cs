﻿using UnityEngine;
using System.Collections;

public class type_dot : MonoBehaviour {

	public type myType;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider who){
//		print (who.name);
		if (who.tag == "enemy") {
//			print ("here");
			type_Atk atkType = who.GetComponent<type_Atk> ();
			if (atkType == null) atkType = who.GetComponentInParent<type_Atk> ();
			if (atkType.atkType == myType) {
				who.SendMessage ("hurt", SendMessageOptions.DontRequireReceiver);
			} else {
				gameObject.SendMessageUpwards ("Die", SendMessageOptions.DontRequireReceiver);
			}
		}
	}
}
