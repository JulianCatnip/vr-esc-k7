using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMarker : MonoBehaviour {

	public GameObject monster;


	void Start(){
	}

	public void OnTriggerEnter(Collider collider){
		if (collider.CompareTag ("Player")) {
			monster.SendMessage ("StartMonsterBehavior");
		}
	}
}
