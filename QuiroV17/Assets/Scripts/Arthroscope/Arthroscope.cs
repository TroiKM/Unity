/* Company: Ludopia
 * Class:  Arthroscope
 * Description:
 * 		Class that represents the Artroscope
 * 
 */

using UnityEngine;
using System.Collections;

public class Arthroscope : MonoBehaviour {

	public static Vector3 initialPosition;
	public static Vector3 lastPosition;
	public static Vector3 currentPosition;

	public static Vector3 initialRotation;
	public static Vector3 currentRotation;

	public static float minimumDeepness;
	public static float maximumDeepness;

	public static Vector3 lastNoCollisionPosition;
	public static Vector3 lastNoCollisionRotation;

	public static float advanceSpeed;
	public static float selfPivotRotationSpeed;
	public static float portalPivotRotationSpeed;
	float speedCorrection = 0.006f;

	public static bool allowMovement;
	public static bool returnToInitialPosition;

	public static GameObject camera;

	// Use this for initialization
	void Start () {

		initialPosition = this.transform.position;
		lastPosition = this.transform.position;
		currentPosition = this.transform.position;

		initialRotation = this.transform.eulerAngles;
		currentRotation = this.transform.eulerAngles;

		minimumDeepness = -2.0f;
		maximumDeepness = 15.0f;

		if (Screen.width > Screen.height) {
			selfPivotRotationSpeed = speedCorrection * Screen.width / Screen.height;
			advanceSpeed =  speedCorrection  * Screen.height / Screen.width ;
		} 
		else {
			selfPivotRotationSpeed =  speedCorrection  * Screen.height / Screen.width ;
			advanceSpeed = speedCorrection  * Screen.width / Screen.height;
		}
		advanceSpeed = advanceSpeed / 3.0f;
		portalPivotRotationSpeed = 0.1f;

		allowMovement = true;
		returnToInitialPosition = false;

		camera = GameObject.Find ("MainCamera");

	}

	public static void saveActualState () {

		lastNoCollisionPosition = currentPosition;
		lastNoCollisionRotation = currentRotation;

	}

	public static float determineSpeed(float currentCoordinate, float initialCoordinate, float baseSpeed) {

		int direction = (currentCoordinate > initialCoordinate) ? 1 : -1;
		return (Mathf.Abs(currentCoordinate - initialCoordinate) * direction * baseSpeed);

	}

	public static void changeCameraRotation (float xRotation) {
		
		/*
		 * this is for avoid mirrors image in the camera
		 */ 
		Vector3 cameraRotation = new Vector3 (xRotation, 180.0f, 0.0f);
		camera.transform.localEulerAngles = cameraRotation;
		MainLayout.arthroscope = !MainLayout.arthroscope;
		
	}

	/*
	 * We use Vector3.up because in the local axis, is equivalent to z global axis
	 */ 
	public static void move (Vector3 transformDirection, float currentCoordinate, float initialCoordinate, float baseSpeed) {

		currentPosition += transformDirection * determineSpeed(currentCoordinate, initialCoordinate, baseSpeed);

	}

	void refreshArthroscope () {

		this.transform.position = currentPosition;
		currentRotation = this.transform.eulerAngles;

	}
	
	// Update is called once per frame
	void Update () {

		if (!allowMovement) {
			if (returnToInitialPosition) {
				currentPosition = initialPosition;
			}
			return;
		}

		refreshArthroscope ();

	}
}
