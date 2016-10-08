using UnityEngine;
using System.Collections;

public class other_disableOtherWhenIDisable : MonoBehaviour {

	public GameObject thisDisable;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnDisable(){
		if(thisDisable.activeSelf) thisDisable.SetActive (false);
	}
}
