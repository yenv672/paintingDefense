using UnityEngine;
using System.Collections;

public class flyOff : MonoBehaviour {

	public bool fly = false;
	public float thrust=1f;
	public float rotationSpeed=50f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (fly == true) {
			flying ();
			fly = false;
		} else {
		}
	}
	void flying(){
		float h =-1 * rotationSpeed * Time.deltaTime;
		float v = 1 * rotationSpeed*Time.deltaTime;

		this.GetComponent<Rigidbody> ().AddTorque(transform.up * h);
		this.GetComponent<Rigidbody> ().AddTorque(transform.right * v);
		this.GetComponent<Rigidbody> ().AddForce (new Vector3(1 * thrust,0,0));
	}
}