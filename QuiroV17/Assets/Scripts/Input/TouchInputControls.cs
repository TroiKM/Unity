/* Company: Ludopia
 * Class:  TouchInputControls
 * Description:
 * 		Class used to manage the input via touch
 * 
 */

using UnityEngine;
using System.Collections;

public class TouchInputControls : MonoBehaviour {

	public static Vector2 initialTouchPosition;
	public static Vector2 lastTouchPosition;
	public static Vector2 currentTouchPosition;

	public Texture2D texture;

	bool inCircle (Vector2 point, Vector2 center, float circleRadius, float pointRadius) {

		return Mathf.Pow(point.x - center.x, 2) + Mathf.Pow(point.y - center.y, 2) <= Mathf.Pow(circleRadius - pointRadius, 2);

	}
	
	void selfPivoteRotate (Vector2 touchPosition) {

		if (Controls2D.horizontalSlider.contains (touchPosition)) {

			Arthroscope.saveActualState();
			this.transform.Rotate(0, - Arthroscope.determineSpeed(touchPosition.x, initialTouchPosition.x, Arthroscope.selfPivotRotationSpeed), 0);

		}

	}

	void portalPivoteRotate (Vector2 touchPosition) {

		Circle portalRotationCircle = Controls2D.portalRotationCircle;
		Circle portalRotationBackgroundCircle = Controls2D.portalRotationBackgroundCircle;
		/*
		 * Remember that in the Circles, we save the center with a little offset for well printing on screen porpuse.
		 * Then, to get the real centers of a circle, we need to sum its radius in x and y
		 */ 
		Vector2 realPortalRotationBackgroundCircleCenter = 
			new Vector2 (
				portalRotationBackgroundCircle.center.x + portalRotationBackgroundCircle.radius, 
				portalRotationBackgroundCircle.center.y + portalRotationBackgroundCircle.radius
			)
		;

		if (portalRotationCircle.contains (touchPosition)) {

			/*
			 * If the portalRotationCircle is in the portalRotationBackgroundCircle
			 */ 
			if (inCircle(currentTouchPosition, realPortalRotationBackgroundCircleCenter, portalRotationBackgroundCircle.radius, portalRotationCircle.radius)) {

				Arthroscope.saveActualState();

				lastTouchPosition = portalRotationCircle.center;
				portalRotationCircle.center = new Vector2 (touchPosition.x - portalRotationCircle.radius, touchPosition.y - portalRotationCircle.radius);

				this.transform.Rotate (Arthroscope.determineSpeed(portalRotationCircle.center.y, lastTouchPosition.y, Arthroscope.portalPivotRotationSpeed) * -1, 0, 0);
				this.transform.Rotate (0, 0, Arthroscope.determineSpeed (portalRotationCircle.center.x, lastTouchPosition.x, Arthroscope.portalPivotRotationSpeed) * -1);

			}

		}

		Controls2D.portalRotationCircle = portalRotationCircle;
		Controls2D.portalRotationBackgroundCircle = portalRotationBackgroundCircle;

	}

	void advance (Vector2 touchPosition) {

		if (Controls2D.verticalSlider.contains(touchPosition)) {

			/*
			 * Remember that both, touchPosition (initialTouchPosition passed as parameter)
			 * and initialTouchPosition has been applied the y axis mirror doing *.y = Screen.height - *.y
			 * 
			 * Remember too that, the y axis mirror described before, has an inverse y axis in the cartesian system, 
			 * thus, the higher is the touch, the lower is its value
			 */ 
			bool goingUp = touchPosition.y > initialTouchPosition.y;
			bool inRange = 
				(goingUp && Arthroscope.currentPosition.z <= Arthroscope.maximumDeepness) ||
				(!goingUp && Arthroscope.currentPosition.z >= Arthroscope.minimumDeepness)
			;
			if (inRange) {
				Arthroscope.saveActualState();
				Arthroscope.move(this.transform.TransformDirection(Vector3.up), currentTouchPosition.y, initialTouchPosition.y, Arthroscope.advanceSpeed);
			}

		}
	}

	// Update is called once per frame
	void Update () {

		/*
		 * Checking for the exit (return) conditions
		 */ 
		if (Input.touchCount <= 0) return;

		foreach (Touch touch in Input.touches) {

			currentTouchPosition = touch.position;
			currentTouchPosition.y = Screen.height - currentTouchPosition.y;

			switch (touch.phase) {
				
				case TouchPhase.Began:
					initialTouchPosition = touch.position;
					initialTouchPosition.y = Screen.height - initialTouchPosition.y;
					break;
				
			}

			advance(currentTouchPosition);
			portalPivoteRotate(currentTouchPosition);
			selfPivoteRotate(currentTouchPosition);

		}

	}

}
