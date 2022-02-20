using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resetable : MonoBehaviour {

	public bool resetPosition = true;
	public bool resetDirection = true;
	Vector3 startPosition;
	Vector3 startDirection;

	// Use this for initialization
	void Start () {
		this.startPosition = this.transform.position;
		this.startDirection = this.transform.forward;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ResetPosition(){
		if (this.resetPosition)
			this.transform.position = this.startPosition;
		if (this.resetDirection)
			this.transform.forward = this.startDirection;
		Debug.Log ("In ResetPosition");
	}
}
