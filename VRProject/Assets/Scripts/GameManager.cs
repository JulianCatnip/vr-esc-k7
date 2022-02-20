using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameState {
	START,
	PLAY,
	END
}
public enum MessageText {
	MESSAGE,
	EVENT,
	TASK
}

public class GameManager : MonoBehaviour {

	public GameState gameState;
	private bool methodCalled = false;
	public StartState startState;
	public PlayState playState;
	public GameObject player;
	public GameObject monster;
	public GameObject messageText;
	public GameObject eventText;
	public GameObject taskText;
	public GameObject doorOpen;
	public GameObject doorClosed;
	public Vector3 startPosition;

	public int eventDuration = 5;
	private int tasks = 0;

	// Use this for initialization
	void Start () {
		startPosition = player.transform.position;
		methodCalled = false;
		gameState = GameState.START;
	}

	public void StartGame () {
		methodCalled = false;
		gameState = GameState.PLAY;
	}

	public void GameOver() {
		ShowMessage(MessageText.MESSAGE, "GAME OVER");
		methodCalled = false;
		gameState = GameState.END;
	}

	public void ShowMessage(MessageText mt, string message) {
		switch (mt) {
		case MessageText.MESSAGE:
			messageText.GetComponentInChildren<Text> ().text = message;
			messageText.SetActive (true);
			;
			break;
		case MessageText.EVENT:
			eventText.GetComponentInChildren<Text> ().text = message;
			StartCoroutine (ShowTimedMessage(message, eventDuration));
			;
			break;
		case MessageText.TASK: // task steht im ersten raum
			taskText.GetComponentInChildren<Text> ().text = message;
			;
			break;
		}
	}

	IEnumerator ShowTimedMessage(string message, int time) {

		eventText.SetActive (true);
		eventText.GetComponent<Text> ().text = message;
		yield return new WaitForSeconds(time);
		// Text deaktivieren
		eventText.SetActive (false);
	}

	void RestartGame() {
		tasks = 0;
		gameState = GameState.START;
		methodCalled = false;
	}

	public void EventTriggered(int eventNr) {
		tasks = eventNr;
		UpdateTaskText ();
		// event message
		string text = tasks + "/2 TASKS FINISHED";
		ShowMessage (MessageText.EVENT, text);
		if(tasks == 2) {
			// tür aktivieren
			doorOpen.SetActive(true);
			doorClosed.SetActive (false);
			// event message
			ShowMessage (MessageText.EVENT, "EXIT IS OPEN");
		}
	}

	private void UpdateTaskText() {
		taskText.transform.Find("Canvas/TaskText").GetComponent<Text>().text = "TASKS TO EXIT " + tasks + "/2";
	}

	// Update is called once per frame
	void Update () {
		switch(gameState) {
		case GameState.START:
				if (!methodCalled) { // start/bzw einmaliger aufruf
					// start view laden
					startState.gameObject.SetActive (true);
					playState.gameObject.SetActive (false);
					
					// texte deaktivieren
					messageText.SetActive (false);
					eventText.SetActive (false);
					eventText.SetActive (false);

					// tür sperren
					doorOpen.SetActive(false);
					doorClosed.SetActive (true);

					// bewegung starten

					methodCalled = true;
				}
				; break;
			case GameState.PLAY:
				if (!methodCalled) { // start/bzw einmaliger aufruf
				Debug.Log("call PLAY()");
					startState.gameObject.SetActive (false);
					playState.gameObject.SetActive (true);
					
					// aufgaben Text aktivieren
					taskText.SetActive (true);

					// spielelogik 
					// kollisionen etc
					// anzeige aufgabe erfüllt

					methodCalled = true;
				}
				; break;
		case GameState.END:
			if (!methodCalled) { // start/bzw einmaliger aufruf
					
				// bewegung stoppen

				BroadcastMessage ("ResetPosition", SendMessageOptions.DontRequireReceiver);
				BroadcastMessage ("ResetProperties", SendMessageOptions.DontRequireReceiver);

				methodCalled = true;
				RestartGame ();
			}
				; break;
		}
	}

	// BEI DURCH DEN RAUM FLIEGEN: AUSKOMMENTIEREN
	// sorgt dafür dass man nach dem Game Over zurück in den StartRaum kommt und nicht an der stelle bleibt an der man gestorben
	public void ResetPosition(){
		player.transform.position = startPosition;
	}
}
