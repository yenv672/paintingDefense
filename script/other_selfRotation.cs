using UnityEngine;
using System.Collections;

public class other_selfRotation : MonoBehaviour {

	public float anglePerFrame = 2f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround (transform.position,Vector3.up,Time.deltaTime*anglePerFrame);
	}
}
