/* Company: Ludopia
 * Class:  PortalsMenu
 * Description:
 * 		Class that manage the Portal's Menu
 * 
 */

using UnityEngine;
using System.Collections.Generic;
using System;

public class PortalsMenu : MonoBehaviour {

	/*
	 * Interface variables
	 */ 
	float WIDTH;
	float HEIGHT;
	
	float DIST_BUTTON;
	float ANCHO_BUTTON;
	float offset;
	
	float WIDTH_BUTTON;
	float HEIGHT_BUTTON;
	float WIDTH_MENU;
	float HEIGHT_MENU;

	/*
	 * Portal's position and rotation
	 */ 

	Vector3 position0 = new Vector3 (-0.02547958f, -1.18448f, 15f);
	Vector3 rotation0 = new Vector3 (90f, 0f, 0f);
	
	Vector3 position1 = new Vector3 (6.693674f, -2.326357f, 10.99725f);
	Vector3 rotation1 = new Vector3 (83.78696f, 189.8611f, 162.4035f);
	
	Vector3 position2 = new Vector3 (-6.287452f, -3.577284f, 11.86309f);
	Vector3 rotation2 = new Vector3 (75.44133f, 174.8502f, 199.0762f);
	
	Vector3 position3 = new Vector3 (-6.9182f, 8.12643f, 13.3237f);
	Vector3 rotation3 = new Vector3 (75.3176f, 318.007f, 345.463f);
	
	Vector3 position4 = new Vector3 (8.6944f, 10.0603f, 14.0572f);
	Vector3 rotation4 = new Vector3 (69.1282f, 344.210f, 314.936f);
	
	Vector3 position5 = new Vector3 (17.2778f, 0.80047f, -0.3466f);
	Vector3 rotation5 = new Vector3 (90f, 90f, 0f);
	
	Vector3 position6 = new Vector3 (-16.351f, 0.80047f, -0.3466f);
	Vector3 rotation6 = new Vector3 (90f, 270f, 0f);

	public GUISkin portalsSkin;

	void Start() {

		WIDTH = Screen.width;
		HEIGHT = Screen.height*0.65f;
		
		DIST_BUTTON =  HEIGHT * 0.1f;
		ANCHO_BUTTON = WIDTH * 0.33f;
		offset = 10.0f;
		
		WIDTH_BUTTON = ANCHO_BUTTON * 0.99f;
		HEIGHT_BUTTON = DIST_BUTTON * 0.95f;
		WIDTH_MENU = WIDTH * 0.1f;
		HEIGHT_MENU = HEIGHT * 0.25f;

	}
	
	public static void rebootControls2D () {

		float diameter = Controls2D.portalRotationBackgroundCircle.diameter / 5;
		Vector2 center = new Vector2 (Screen.width / 2 - diameter / 2, 3 * Screen.height / 4 - diameter / 2);
		Controls2D.portalRotationCircle.center = center;

		TouchInputControls.lastTouchPosition = new Vector2 (0, 0);

	}
	
	void moveArthroscopeToPortal (Vector3 posicion, Vector3 rotacion) {
		Arthroscope.currentPosition = posicion;
		this.transform.eulerAngles = rotacion;	
		rebootControls2D();
		MainLayout.arthroscope = !MainLayout.arthroscope;

	}

	/* Menu de resultados  */ 
	void OnGUI() {

		Texture2D botonOriginal = new GUIStyle("button").normal.background;
		
		if (MainLayout.arthroscope) {

			GUI.depth = 3;
			float distance = 2.2f;
			float LSeparation = 0.3f;
			float BSeparation = 0.4f;
			
			if (portalsSkin) GUI.skin = portalsSkin;
			
			GUI.Box(new Rect (WIDTH_MENU,HEIGHT_MENU , WIDTH * 0.8f, HEIGHT), "Artroscopio.");
			
			GUI.skin.label.fontSize = (int)(Math.Round ((double)WIDTH_MENU * 0.7f, 0));
			
			/*
			 * Angle's labels
			 */ 
			GUI.Label(new Rect(WIDTH_MENU * 3.5f,HEIGHT_MENU * 1.5f, WIDTH, HEIGHT_BUTTON), "Angulos ");
			
			/*
			 * 0 degrees button
			 */ 
			if (
				GUI.Button (new Rect (WIDTH_MENU * 1.1f , 
			                      HEIGHT_MENU * 1.8f, 
			                      WIDTH_BUTTON * 0.7f, 
			                      HEIGHT_BUTTON * 0.7f), "0°")
				)
			{
				Arthroscope.changeCameraRotation(90.0f);
			}
			
			/*
			 * 30 degrees button
			 */ 
			if (
				GUI.Button (new Rect (WIDTH_MENU + WIDTH_BUTTON *0.7f + 10.0f, 
			                      HEIGHT_MENU * 1.8f, 
			                      WIDTH_BUTTON *0.7f, 
			                      HEIGHT_BUTTON * 0.7f), "30°")
				) 
			{

				Arthroscope.changeCameraRotation(120.0f);
			}
			
			/*
			 * 70 degrees button
			 */ 
			if (
				GUI.Button (new Rect (WIDTH_MENU + ((WIDTH_BUTTON * 0.7f) * 2.0f )+ 20.0f , 
			                      HEIGHT_MENU * 1.8f, 
			                      WIDTH_BUTTON * 0.7f, 
			                      HEIGHT_BUTTON * 0.7f), "70°")
				)
			{
				Arthroscope.changeCameraRotation(160.0f);
			}
			
			/*
			 * End angle's labels 
			 */

			/*
			 * Portals 
			 */ 
			
			/*
			 * Portal's label
			 */ 
			GUI.Label(new Rect(WIDTH_MENU * 3.5f,HEIGHT_MENU * distance, WIDTH, HEIGHT_BUTTON), "Portales ");
			
			if (
				GUI.Button (new Rect (WIDTH_MENU * 3.3f , 
			                      HEIGHT_MENU * (distance = distance + LSeparation), 
			                      WIDTH_BUTTON, 
			                      HEIGHT_BUTTON * 0.7f), "Anterocentral")
				)
			{
				moveArthroscopeToPortal(position0, rotation0);

			}
			
			if (
				GUI.Button (new Rect (WIDTH_MENU * 1.1f , 
			                      HEIGHT_MENU * (distance = distance + BSeparation), 
			                      WIDTH_BUTTON, 
			                      HEIGHT_BUTTON * 0.7f), "Anterolateral")
				)
			{
				moveArthroscopeToPortal(position1, rotation1);
			}
			
			if (
				GUI.Button (new Rect (WIDTH_MENU * 5.5f , 
			                      HEIGHT_MENU * (distance), 
			                      WIDTH_BUTTON + offset, 
			                      HEIGHT_BUTTON * 0.7f), "Anteromedial")
				) 
			{
				moveArthroscopeToPortal(position2, rotation2);
			}
			
			if (
				GUI.Button (new Rect (WIDTH_MENU * 1.1f , 
			                      HEIGHT_MENU * (distance = distance + BSeparation), 
			                      WIDTH_BUTTON, 
			                      HEIGHT_BUTTON * 0.7f), "Superolateral")
				) 
			{
				moveArthroscopeToPortal(position4, rotation4);
			}
			
			if (
				GUI.Button (new Rect (WIDTH_MENU * 5.5f , 
			                      HEIGHT_MENU * (distance), 
			                      WIDTH_BUTTON + offset, 
			                      HEIGHT_BUTTON * 0.7f), "Superomedial")
				)
			{
				moveArthroscopeToPortal(position3, rotation3);
			}
			
			if (
				GUI.Button (new Rect (WIDTH_MENU * 1.1f , 
			                      HEIGHT_MENU * (distance = distance + BSeparation), 
			                      WIDTH_BUTTON, 
			                      HEIGHT_BUTTON * 0.7f), "Posterolateral")
				) 
			{
				moveArthroscopeToPortal(position5, rotation5);
			}
			
			if (
				GUI.Button (new Rect (WIDTH_MENU * 5.5f , 
			                      HEIGHT_MENU * (distance), 
			                      WIDTH_BUTTON + offset, 
			                      HEIGHT_BUTTON * 0.7f), "Posteromedial")
				)
			{
				moveArthroscopeToPortal(position6, rotation6);
			}

			/*
			 * Continue button
			 */ 
			if (GUI.Button (new Rect (WIDTH * 0.01f + ANCHO_BUTTON + offset, 
			                          (HEIGHT + HEIGHT_BUTTON * 1.7f),
			                          WIDTH_BUTTON, 
			                          HEIGHT_BUTTON), "Continuar")) 
			{
				MainLayout.arthroscope = !MainLayout.arthroscope;
			}
			
		}
	}
}
