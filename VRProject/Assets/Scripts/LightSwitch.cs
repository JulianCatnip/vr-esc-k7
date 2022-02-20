using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]
public class LightSwitch : MonoBehaviour {

	public GameManager gameManager;
	public bool onSwitch;
	public GameObject theLight;
	public bool lightIsActivated = false;
	AudioSource audioSource;

	void Start(){
		audioSource = GetComponent<AudioSource>();
	}

	void OnTriggerEnter(Collider other)
	{
		onSwitch = true;
		audioSource.Play ();
	}

	void OnTriggerExit(Collider other)
	{
		onSwitch = false;
		audioSource.Pause();
	}

	void Update()
	{

		if (onSwitch)
		{
			/*if (OVRInput.Get(OVRInput.Button.One))
            {
				theLight.SetActive(true);
				lightIsActivated = true;
            }*/
		}
	}

	/*void OnGUI()
    {
        if (onSwitch)
        {
            if (lightStatus)
            {
                GUI.Box(new Rect(0, 0, 200, 20), "Press E");
 
            }
            else
            {
                GUI.Box(new Rect(0, 0, 200, 20), "Press E");
            }
        }
    }*/

	public void ResetProperties(){
		Debug.Log ("In ResetProperties");
		this.onSwitch = false;
		this.theLight.SetActive(false);
		lightIsActivated = false;
	}

	public void TurnLightsOn(){
		//theLight.SetActive (true);
		lightIsActivated = true;
		audioSource.Stop ();
		Transform lights = theLight.GetComponent<Transform>();
		//Lamp[] lamps = FindObjectsOfType<Lamp>();
		foreach (Transform light in lights) {
			light.GetComponent<Lamp>().enabled = false;
			light.GetComponent<AudioSource>().Stop();
		}
		gameManager.EventTriggered (2);

	}

}