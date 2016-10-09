using UnityEngine;
using System.Collections;

public class sound_playThese : MonoBehaviour {

	public AudioClip[] playThese;
	int playInt = 0;
	AudioSource audio;
	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource> ();
		audio.Stop ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public delegate void callback(); // declare delegate type

	public void playTheseClip(){
//		print ("here "+audio.isPlaying);
		if (!audio.isPlaying) {
			audio.clip = playThese [playInt];
			audio.Play ();
			StartCoroutine(DelayedCallback(playThese [playInt].length, endSound));
			if (playInt + 1 < playThese.Length - 1)
				playInt += 1;
		}
	}

	void endSound(){
		audio.Stop ();
	}

	private IEnumerator DelayedCallback(float time, callback cb)
	{
		yield return new WaitForSeconds(time);
		cb ();
	}
}
