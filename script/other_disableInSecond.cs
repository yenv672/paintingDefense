using UnityEngine;
using System.Collections;

public class other_disableInSecond : MonoBehaviour {

    public int disableInSce = 2;
    float startingTime = -1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (startingTime != -1 && startingTime + disableInSce < Time.time) gameObject.SetActive(false);
	}

    void OnEnable() {
        startingTime = Time.time;
    }

    void OnDisable() {
        startingTime = -1;
    }
}
