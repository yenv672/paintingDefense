using UnityEngine;
using System.Collections;

public class other_follow : MonoBehaviour {

	public Transform followThis;
	Vector3 relativePos;

	// Use this for initialization
	void Start () {
		relativePos = transform.position - followThis.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = relativePos + followThis.position;
	}
}
