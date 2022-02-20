using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class Lamp : MonoBehaviour {

	private Light lamp1;
	private Light lamp2;
	public Texture2D enabledTex;
	public Texture2D disabledTex;
	AudioSource audioSource;
	float timer = 1;

	// Use this for initialization
	void Start () {
		lamp1 = transform.Find ("Light1").GetComponent<Light> ();
		lamp2 = transform.Find ("Light2").GetComponent<Light> ();
		audioSource = GetComponent<AudioSource> ();
	}

	IEnumerator FlackeringLight(float time) {
		lamp1.enabled = false; //turn it off
		lamp2.enabled = false; //turn it off
		this.transform.GetComponent<Renderer> ().material.SetTexture ("_EmissionMap", disabledTex);
		this.transform.GetComponent<Renderer> ().material.SetColor("_EmissionColor", Color.black);
		if (audioSource != null)
			audioSource.Pause ();
		yield return new WaitForSeconds(time);
		timer++;
		if (timer < 200) { // nach 6 sek
			lamp1.enabled = false; //turn it off
			lamp2.enabled = false; //turn it off
			this.transform.GetComponent<Renderer> ().material.SetTexture ("_EmissionMap", disabledTex);
			this.transform.GetComponent<Renderer> ().material.SetColor("_EmissionColor", Color.black);
			if (audioSource != null)
				audioSource.Pause ();
		} else if (timer >= 200 && timer < 215) { // sonst aus
			lamp1.enabled = true; //turn it on
			lamp2.enabled = true; //turn it on
			this.transform.GetComponent<Renderer> ().material.SetTexture ("_EmissionMap", enabledTex);
			this.transform.GetComponent<Renderer> ().material.SetColor("_EmissionColor", Color.white);
			if (audioSource != null) 
				audioSource.Play ();
		} else if (timer >= 215 && timer < 230) { // sonst aus
			lamp1.enabled = false; //turn it off
			lamp2.enabled = false; //turn it off
			this.transform.GetComponent<Renderer> ().material.SetTexture ("_EmissionMap", disabledTex);
			this.transform.GetComponent<Renderer> ().material.SetColor("_EmissionColor", Color.black);
			if (audioSource != null)
				audioSource.Pause ();
		} else if (timer >= 230 && timer < 245) { // sonst aus
			lamp1.enabled = true; //turn it on
			lamp2.enabled = true; //turn it on
			this.transform.GetComponent<Renderer> ().material.SetTexture ("_EmissionMap", enabledTex);
			this.transform.GetComponent<Renderer> ().material.SetColor("_EmissionColor", Color.white);
			if (audioSource != null) 
				audioSource.Play ();
		} else if (timer >= 245 && timer < 260) { // sonst aus
			lamp1.enabled = false; //turn it off
			lamp2.enabled = false; //turn it off
			this.transform.GetComponent<Renderer> ().material.SetTexture ("_EmissionMap", disabledTex);
			this.transform.GetComponent<Renderer> ().material.SetColor("_EmissionColor", Color.black);
			if (audioSource != null)
				audioSource.Pause ();
		} else if (timer >= 260 && timer < 275) { // sonst aus
			lamp1.enabled = true; //turn it on
			lamp2.enabled = true; //turn it on
			this.transform.GetComponent<Renderer> ().material.SetTexture ("_EmissionMap", enabledTex);
			this.transform.GetComponent<Renderer> ().material.SetColor("_EmissionColor", Color.white);
			if (audioSource != null) 
				audioSource.Play ();

			timer = 1;
		}
	}
	
	// Update is called once per frame
	void Update () {
		// lang aus
		StartCoroutine(FlackeringLight(Random.Range(5.0f, 20.0f)));
	}
}
