/* Company: Ludopia
 * Class:  Collisions
 * Description:
 * 		Class used to manage Arthroscope's collisions
 * 
 */

using UnityEngine;
using System.Collections;

public class Collisions : MonoBehaviour {

	public static int amountCollisions;
	public static bool showNonCameraCollisionMessage;

	public static string message;
	
	public Texture collisionCameraAlertTexture;
	bool showCollisionCameraAlert;
	int collisionCameraAlertSeconds = 3;
	int nonCameraCollisionSeconds = 1;

	public GUISkin collisionSkin;
	
	// Use this for initialization
	void Start () {
				
		amountCollisions = 0;
		showNonCameraCollisionMessage = false;
		message = "";
		showCollisionCameraAlert = false;

	}
	
	/*
	 * Non camera collisions
	 */ 
	void OnCollisionEnter (Collision colision) {

		amountCollisions++;
		showNonCameraCollisionMessage = true;
		message = "¡Intenta no chocar!";
		this.transform.position = Arthroscope.lastNoCollisionPosition;
		this.transform.eulerAngles = Arthroscope.lastNoCollisionRotation;
		this.rigidbody.constraints = RigidbodyConstraints.FreezeAll;
		StartCoroutine(FreezeArthroscope());

	}
	
	public bool detectCameraCollision () {

		bool result = false;
		float deltaRay = 0.1f;
		float rayDistance = 0.1f;
		/*
		 * Prepare the ray
		 */ 
		Ray [] rays = new Ray[5];
		rays[0] = MainLayout.cam2.ScreenPointToRay (new Vector3(Screen.width / 2, 3*Screen.height/4.0f, 0));
		rays[1] = new Ray(new Vector3(rays[0].origin.x - deltaRay, rays[0].origin.y - deltaRay, rays[0].origin.z), rays[0].direction);
		rays[2] = new Ray(new Vector3(rays[0].origin.x - deltaRay, rays[0].origin.y + deltaRay, rays[0].origin.z), rays[0].direction);
		rays[3] = new Ray(new Vector3(rays[0].origin.x + deltaRay, rays[0].origin.y - deltaRay, rays[0].origin.z), rays[0].direction);
		rays[4] = new Ray(new Vector3(rays[0].origin.x + deltaRay, rays[0].origin.y + deltaRay, rays[0].origin.z), rays[0].direction);

		/*
		 * hit is an object hitted by the ray
		 */
		RaycastHit hit;
		for (int i = 0; i < 5; i++) {
			if (Physics.Raycast(rays[i], out hit, rayDistance)) {
				if (hit.collider.gameObject.name != "Sphere") {
					message = "¡No choques la camara!";
					showNonCameraCollisionMessage = true;
					amountCollisions++;
					result = true;
				}
			}
			Debug.DrawRay (rays[i].origin, rays[i].direction * rayDistance, Color.blue);
		}
		return result;
		
	}
	
	void OnGUI() {

		Texture2D originalButton = new GUIStyle("button").normal.background;

		if (showNonCameraCollisionMessage) {

			GUI.depth = 1;
			
			if (collisionSkin) GUI.skin = collisionSkin;
			
			GUI.Box (new Rect (ScreenVariables.WIDTH * 0.1f, ScreenVariables.HEIGHT * 0.7f, ScreenVariables.WIDTH * 0.8f, ScreenVariables.HEIGHT * 0.5f), message);
			GUI.skin.GetStyle("button").normal.background = originalButton;
			
			// Accept message button
			float x = Screen.width / 2 - ScreenVariables.WIDTH_BUTTON / 2;
			if (GUI.Button (new Rect (x, ScreenVariables.HEIGHT, ScreenVariables.WIDTH_BUTTON, ScreenVariables.HEIGHT_BUTTON), "Continuar")) {
				showNonCameraCollisionMessage = false;
			}

		}
		if (showCollisionCameraAlert) {

			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), collisionCameraAlertTexture);
		
		}
		
		
	}
	 
	IEnumerator DenyArthroscopeMovementAndSetInitialPosition() {
		/*
		 * Before waiting
		 */ 
		Arthroscope.allowMovement = false;
		Arthroscope.returnToInitialPosition = true;
		MainLayout.arthroscope = false;
		yield return new WaitForSeconds(collisionCameraAlertSeconds);
		/*
		 * After waiting
		 */ 
		Arthroscope.allowMovement = true;
		Arthroscope.returnToInitialPosition = false;
	}
	
	IEnumerator FreezeArthroscope() {
		/*
		 * Before waiting 
		 */ 
		Arthroscope.returnToInitialPosition = false;
		Arthroscope.allowMovement = false;
		MainLayout.arthroscope = false;
		yield return new WaitForSeconds(nonCameraCollisionSeconds);
		/*
		 * After waiting 
		 */ 
		Arthroscope.allowMovement = true;
	}
	
	IEnumerator blink() {

		float stepSeg = 0.5f;
		float totalSeg = collisionCameraAlertSeconds;
		float numberLoops = totalSeg / stepSeg;
		for (float i = 0; i < numberLoops; i++) {
			showCollisionCameraAlert = true;
			yield return new WaitForSeconds(stepSeg/2);
			showCollisionCameraAlert = false;
			yield return new WaitForSeconds(stepSeg/2);
			
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (detectCameraCollision ()) {

			this.transform.position = Arthroscope.initialPosition;
			this.transform.eulerAngles = Arthroscope.initialRotation;
			Arthroscope.changeCameraRotation(90.0f);
			
			this.rigidbody.constraints = RigidbodyConstraints.FreezeAll;
			
			StartCoroutine(DenyArthroscopeMovementAndSetInitialPosition());
			StartCoroutine(blink());

			PortalsMenu.rebootControls2D();

		}
		
	}
}

