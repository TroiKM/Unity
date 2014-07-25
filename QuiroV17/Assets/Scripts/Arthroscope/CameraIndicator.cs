/* Company: Ludopia
 * Class:  CameraIndicator
 * Description:
 * 		Manager class of the Arthroscope's camera indicator
 * 
 */


using UnityEngine;
using System.Collections;

public class CameraIndicator : MonoBehaviour {

	public static float rotationAngle = 0;
	public static Vector2 pivotPoint;
	public Texture cursor;
	
	// Use this for initialization
	void Start () {
		rotationAngle = 0;
	}
	public void rotateCameraIndicator () {

		/*
		 * Cursor
		 */ 
		Vector2 size;
		if ((Screen.width * 6.0f) < ((Screen.height/2) * 5.0f)) {
			size = new Vector2 (Screen.width * 6.0f, Screen.width * 6.0f);
		} else {
			size = new Vector2 (((Screen.height/2) * 5.0f), ((Screen.height/2) * 5.0f));
		}
		pivotPoint = new Vector2(Screen.width/2, (Screen.height/4));
		
		GUIUtility.RotateAroundPivot(rotationAngle, pivotPoint);
		GUI.DrawTexture(new Rect(Screen.width/2.2f - size.x/2, (Screen.height/8 - size.y/2) + size.y/15, size.x, size.y), cursor);
		
	}
	
	void OnGUI() {
		if (MainLayout.cam2.enabled) {
			GUI.depth = 5;
			rotateCameraIndicator ();
		}
	}
}
