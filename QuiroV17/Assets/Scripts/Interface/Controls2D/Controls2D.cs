/* Company: Ludopia
 * Class: Controls2D
 * Description:
 * 		Class used to manage the arthroscope's controllers with:
 * 			1 Horizontal ArrowSlider for the self axis rotation
 * 			1 Vertical ArrowSlider for the advance
 * 			1 DraggableCircle for the portal rotation
 * 			1 Circle as the DraggableCircle's background
 * 
 */

using UnityEngine;
using System.Collections;

public class Controls2D : MonoBehaviour {

	/*
	 * ArrowSliders (textures are public for editor assignment purpose)
	 */ 
	public static ArrowSlider horizontalSlider;
	public Texture2D horizontalSliderTexture;
	public static ArrowSlider verticalSlider;
	public Texture2D verticalSliderTexture;

	/*
	 * Circles
	 */ 
	public static Circle portalRotationBackgroundCircle;
	public Texture2D portalRotationBackgroundCircleTexture;
	public static Circle portalRotationCircle;
	public Texture2D portalRotationCircleTexture;

	public static Vector3 lastPortalRotationCirclePosition;

	void initializeSliders () {

		Vector2 horizontalSliderCenter = new Vector2 (0.125f * Screen.width, ScreenVariables.HEIGHT + 1.25f * ScreenVariables.HEIGHT_BUTTON);
		Vector2 horizontalSliderSize = new Vector2 (0.75f * Screen.width, ScreenVariables.HEIGHT_BUTTON/2);

		Vector2 verticalSliderCenter = new Vector2 (0.125f / 2.0f * Screen.width, Screen.height / 2 + 1.5f * ScreenVariables.HEIGHT_BUTTON);
		Vector2 verticalSliderSize = new Vector2 (0.125f / 3.0f * Screen.width, (Screen.height / 2 - 3 * ScreenVariables.HEIGHT_BUTTON));

		/*
		 * Because boths ArrowSlider should have the same width
		 */ 
		float minimumWidth = Mathf.Min (horizontalSliderSize.y, verticalSliderSize.x);
		horizontalSliderSize.y = minimumWidth;
		verticalSliderSize.x = minimumWidth;

		horizontalSlider = new ArrowSlider (horizontalSliderCenter, horizontalSliderSize, horizontalSliderTexture);
		verticalSlider = new ArrowSlider (verticalSliderCenter, verticalSliderSize, verticalSliderTexture);

	}

	void initializePortalRotationBackgroundCircle () {

		float diameter;
		Vector2 center;
		float verticalDistance = Mathf.Abs (Screen.width / 2 - verticalSlider.position.x) - verticalSlider.size.x / 2 - ScreenVariables.DIST_BUTTON * 0.35f;
		float horizontalDistance = Mathf.Abs (3 * Screen.height / 4 - horizontalSlider.position.y) - horizontalSlider.size.y / 2 - ScreenVariables.DIST_BUTTON * 0.35f;

		float minimumDistance = Mathf.Min (verticalDistance, horizontalDistance);
		diameter = 2 * minimumDistance;

		center = new Vector2 (Screen.width / 2 - diameter / 2, 3 * Screen.height / 4 - diameter / 2);
		portalRotationBackgroundCircle = new Circle (center, diameter / 2, portalRotationBackgroundCircleTexture);

	}

	void initializePortalRotationCircle () {

		float diameter = portalRotationBackgroundCircle.diameter / 5;
		Vector2 center = new Vector2 (Screen.width / 2 - diameter / 2, 3 * Screen.height / 4 - diameter / 2);
		portalRotationCircle = new DraggableCircle (center, diameter /2, portalRotationCircleTexture);

	}

	void initializeCircles () {

		initializePortalRotationBackgroundCircle ();
		initializePortalRotationCircle ();

	}

	void printSliders () {

		horizontalSlider.print ();
		verticalSlider.print ();

	}

	void printCircles () {

		portalRotationBackgroundCircle.print ();
		portalRotationCircle.print ();

	}

	// Use this for initialization
	void Start () {

		initializeSliders ();
		initializeCircles ();

	}

	void OnGUI() {

		GUI.depth = 3;
		if (MainLayout.cam2.enabled) {
			printSliders ();
			printCircles ();
		}

	}
}
