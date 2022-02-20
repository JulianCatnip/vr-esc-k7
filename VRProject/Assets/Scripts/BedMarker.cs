using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedMarker : MonoBehaviour {

	public GameObject bed;
	public bool bedIsInFrontOfDoor;

	void Start(){
	}

	public void OnTriggerExit(Collider collider){
		if (collider == bed) {
			bedIsInFrontOfDoor = false;
		}
	}

	public void OnTriggerStay(Collider collider){
		if (collider == bed) {
			bedIsInFrontOfDoor = true;
		}
	}

	public void OnTriggerEnter(Collider collider){
		if (collider == bed) {
			bedIsInFrontOfDoor = true;
		}
	}
}
