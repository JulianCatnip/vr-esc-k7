using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class Door_Sound : MonoBehaviour {

	Vector3 startPosition;
	Vector3 lastPosition;
	AudioSource audioSrc;

	// Use this for initialization
	void Start () {
		startPosition = this.transform.forward;
		lastPosition = this.transform.forward;
		audioSrc = this.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 position = this.transform.forward;
		// Tür bewegt sich -> spiele Audio
		if (position != lastPosition) {
			// Nur wenn Audio nicht schon am spielen ist
			if (!audioSrc.isPlaying) {
				Debug.Log ("Play Audio");
				audioSrc.Play ();
			}
		} else {
			// Tür bewegt sich nicht (mehr) -> pausiere Audio
			audioSrc.Pause ();
		}

		lastPosition = position;

	}
}
