/* Company: Ludopia
 * Class:  ResultsMenu
 * Description:
 * 		Class used to manage the Final Results Menu
 * 
 */

using UnityEngine;
using System.Collections;
using System;


public class ResultsMenu : MonoBehaviour {

	float WIDTH_MENU = ScreenVariables.WIDTH * 0.1f;
	float HEIGHT_MENU = ScreenVariables.HEIGHT * 0.4f;

	public GUISkin resultTexture = null;

	string calification  = "Buena" ;

	public static bool showResultMenu;

	// Use this for initialization
	void Start () {

		showResultMenu = false;

	}

	/* 
	 * Results menu
	 */ 
	void OnGUI() {

		Texture2D originalButton = new GUIStyle("button").normal.background;
		
		if (Targets.seenAmountTargets == Targets.amountTargets || showResultMenu) {

			MainLayout.paused = true;
			
			GUI.depth = 1;
			
			if (resultTexture) GUI.skin = resultTexture;
			
			GUI.Box(new Rect (WIDTH_MENU,HEIGHT_MENU , ScreenVariables.WIDTH * 0.8f, ScreenVariables.HEIGHT), "Desempeño.");
			
			GUI.skin.label.fontSize = (int)(Math.Round ((double)WIDTH_MENU * 0.3f, 0));
			/*
			 * Time label
			 */ 
			GUI.Label(new Rect(WIDTH_MENU * 2.0f,HEIGHT_MENU * 1.5f, ScreenVariables.WIDTH, ScreenVariables.HEIGHT_BUTTON), "Tiempo total: " + MainLayout.time + ".");
			/*
			 * Targets label
			 */
			GUI.Label(new Rect(WIDTH_MENU * 2.0f,HEIGHT_MENU * 1.8f, ScreenVariables.WIDTH, ScreenVariables.HEIGHT_BUTTON), "Cant. de objetivos encontrados: " + Targets.seenAmountTargets + ".");
			/*
			 * Collisions label
			 */
			GUI.Label(new Rect(WIDTH_MENU * 2.0f,HEIGHT_MENU * 2.1f, ScreenVariables.WIDTH, ScreenVariables.HEIGHT_BUTTON), "Num. colisiones: " + Collisions.amountCollisions + ".");
			
			/*
			 * Calification label
			 */
			if (MainLayout.mins <= 1 ) {
				calification = "Excelente";
			}
			else if ( MainLayout.mins > 1 && MainLayout.mins <= 2  ) {
				calification = "Buena";
			}
			else {
				calification = "Regular";
			}
			
			GUI.Label(new Rect(WIDTH_MENU * 2.0f,HEIGHT_MENU * 2.4f, 200, 120), "Calificacion: "+ calification +".");
			
			
			GUI.skin.GetStyle ("button").normal.background = originalButton;
			
			/*
			 * Pause Button
			 */ 
			if (GUI.Button (new Rect (ScreenVariables.WIDTH * 0.2f + ScreenVariables.ANCHO_BUTTON + ScreenVariables.OFFSET, 
			                          (ScreenVariables.HEIGHT + ScreenVariables.HEIGHT_BUTTON * 1.8f),
			                          ScreenVariables.WIDTH_BUTTON, 
			                          ScreenVariables.HEIGHT_BUTTON), "Salir")) {
				Application.LoadLevel (Application.loadedLevel);
			}
			
			/*
			 * Reboot Button
			 */
			if (GUI.Button (new Rect (ScreenVariables.WIDTH * 0.15f + ScreenVariables.ANCHO_BUTTON * 0.01f + ScreenVariables.OFFSET, 
			                          (ScreenVariables.HEIGHT + ScreenVariables.HEIGHT_BUTTON * 1.8f),
			                          ScreenVariables.WIDTH_BUTTON, 
			                          ScreenVariables.HEIGHT_BUTTON), "Reiniciar")) {
				Application.LoadLevel (Application.loadedLevel);
			}
			
		}
	}
}
