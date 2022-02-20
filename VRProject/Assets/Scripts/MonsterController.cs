using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BehaviorTrigger{
	DOORENTER,
	LIGHTSWITCH,
	BED
}

public class MonsterController : MonoBehaviour {

	private GameManager gameManager;
	Animator anim;
	//CharacterController player;
	public GameObject player;
	SphereCollider stopMarker;
	GameObject monster;
	AudioSource[] audioSources;
	public bool roaring;
	AudioSource roar;
	/*
	public float leftBorder;
	public float rightBorder;
	public float topBorder;
	public float bottomBorder;
	*/
	public BehaviorTrigger behaviorTrigger;
	public LightSwitch lightSwitch;
	public PassedMarker passedMarker;
	public BedMarker bedMarker;



	// Use this for initialization
	void Start () {
		gameManager = FindObjectOfType<GameManager> ();
		anim = this.GetComponent<Animator> ();
		stopMarker = GameObject.FindGameObjectWithTag ("StopMarker").GetComponent<SphereCollider> ();
		anim.Play("idle");
		roaring = false;
		audioSources = this.GetComponents<AudioSource> ();
		audioSources [0].Play ();



	}
	
	// Update is called once per frame
	void Update () {
		
		// Playerposistion mit gleicher augenhöhe wie mit dem monster
		Vector3 playerPosition = new Vector3(player.transform.position.x, -this.transform.position.y, player.transform.position.z);
		// Richtung für das monster
		Vector3 direction = playerPosition - this.transform.position;
		/*
		if (!audioSources [1].isPlaying) {
			float delay = Random.Range (0.0f, 1.2f);
			audioSources [1].PlayDelayed (delay);
		}*/

		// Wenn Abstand zwischen Monster und Player nicht zu klein ist (stehen "ineinander")
		if (Vector3.Magnitude (direction) > 1) {
			// setze monsterrichtung
			this.transform.forward = direction;
		}

		// Wenn Abstand kleiner 4
		else if (Vector3.Magnitude (direction) < 4 && Vector3.Magnitude(direction) > 1) {
			// starte Atemgeräusche
			if (!audioSources [1].isPlaying) {
				float delay = Random.Range (0.0f, 1.2f);
				audioSources [1].PlayDelayed (delay);
			}
			audioSources [2].Stop ();
			roaring = false;
		}
		// Wenn Abstand kleiner 1 -> Monster und Spieler sind in der Nähe voneinander
		else if (Vector3.Magnitude(direction) < 1) {
			// Wenn roar nicht schon spielt
			if (!audioSources [2].isPlaying) {
				roaring = true;
				float delay = Random.Range (0.0f, 1.0f);
				// Spiel roar
				audioSources [2].PlayDelayed (delay);
				// Beende Atemgeräusch
				audioSources [1].Stop ();
			}

			// GAME OVER 
			gameManager.GameOver();
		}


		switch (behaviorTrigger) {
		case BehaviorTrigger.DOORENTER:
			// wenn durch Türrahmen gelaufen
			// Alle Eigenschaften von Außen geregelt
			break;

		case BehaviorTrigger.BED:
			
			if (passedMarker.playerPassed && !bedMarker.bedIsInFrontOfDoor) {
				this.StartMonsterBehavior ();
			} 
			if (bedMarker.bedIsInFrontOfDoor) {
				this.StopMonsterBehavior ();
				gameManager.EventTriggered (1);
			}

			break;

		case BehaviorTrigger.LIGHTSWITCH:

			if (passedMarker.playerPassed && !lightSwitch.lightIsActivated) {
				this.StartMonsterBehavior ();
			} 
			break;
		}

	}

	public void ResetProperties(){
		Debug.Log ("In MonsterCon resetProps");
		roaring = false;
		anim.enabled = false;
		foreach (AudioSource a in audioSources) {
			a.enabled = false;
		}
	}

	public void StartMonsterBehavior(){
		anim.enabled = true;
		if (!audioSources[1].isPlaying)
			audioSources [1].Play ();
	}

	public void StopMonsterBehavior(){
		anim.enabled = false;
		audioSources [1].Pause ();
	}

}
