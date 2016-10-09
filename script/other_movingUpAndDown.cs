using UnityEngine;
using System.Collections;

public class other_movingUpAndDown : MonoBehaviour {

	public Transform spot_one;
	public Transform spot_two;
	public float frequence = 0.1f;
	float rdFactor;
	// Use this for initialization
	void Start () {
		rdFactor = Random.Range (0f,2f);
	}
	
	// Update is called once per frame
	void Update () {
		float whereNow = Mathf.Sin (Time.time * rdFactor *frequence)+1;//between 0~2
		transform.position = spot_one.position+( (spot_two.position-spot_one.position)*(whereNow/2));
	}
}
