using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
public class type_line : MonoBehaviour {

	public List<GameObject> dots = new List<GameObject> ();
//	public bool donePainting = false;
	[System.Serializable]
	public class MyEventType : UnityEvent { }
	public MyEventType DieEvent;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Die(){
//		print ("here DIE");
		DieEvent.Invoke();
		foreach (GameObject obj in dots) {
			obj.SetActive (false);
			obj.transform.SetParent (null);
		}
		dots.Clear ();
		gameObject.SetActive (false);
	}
		
}
