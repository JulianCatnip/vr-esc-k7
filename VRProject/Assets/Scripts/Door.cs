using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

	private Rigidbody rigidbody;
	private float rotationAngle;
	private Vector3 fixPosition;
	private float comparison;
	private Quaternion rotationNorm;
	/*private Vector3 localVelocity;*/

	// Use this for initialization
	void Start () {
		fixPosition = transform.position;
		rigidbody = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update () {

		transform.position = fixPosition;
		Quaternion rotationQ = transform.rotation;
		Vector3 rotationE = rotationQ.eulerAngles;
		rotationAngle = rotationE.y;

		rigidbody.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

		// wenn kleiner als null (wenn kleiner als 0 grad) bis 90 
		if (rotationAngle > 0 && rotationAngle < 180) {
			transform.eulerAngles = Vector3.up * 0;
		} else if (rotationAngle > 180 && rotationAngle < 219) {
			transform.eulerAngles = Vector3.up * 219;
		}

		/*if (rotationAngle < 219) {
			// alle achsen einfrieren
			rigidbody.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
			transform.eulerAngles = Vector3.up * 219;
		} else {
			// rotation um y erlauben
			rigidbody.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
		}*/
	}
}
