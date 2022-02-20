using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassedMarker : MonoBehaviour {

	public bool playerPassed = false;

	void Start(){
	}

	public void OnTriggerExit(Collider collider){
		if (collider.CompareTag("Player")) {
			playerPassed = true;
		}
	}
}
