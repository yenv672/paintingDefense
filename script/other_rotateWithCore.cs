using UnityEngine;
using System.Collections;

public class other_rotateWithCore : MonoBehaviour {

	public GameObject myHeart;

	// Use this for initialization
	void Start () {
		StartCoroutine (rotate());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator rotate(){
		while (true) {
			transform.RotateAround (myHeart.transform.position,Vector3.up,15f);
			yield return new WaitForSeconds (1);
		}
	}
}
