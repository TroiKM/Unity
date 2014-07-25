/* Company: Ludopia
 * Class:  PauseMenu
 * Description:
 * 		Class used to manage the pause menu
 * 
 */

using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	public GUISkin pauseSkin;

	void printContinueButton () {

		/*
		 * Continue button
		 */ 
		if (GUI.Button (new Rect (
			ScreenVariables.WIDTH * 0.2f + ScreenVariables.ANCHO_BUTTON + ScreenVariables.OFFSET, 
			(ScreenVariables.HEIGHT),
			ScreenVariables.WIDTH_BUTTON, 
			ScreenVariables.HEIGHT_BUTTON), "Continuar")) 
		{
			
			if (!MainLayout.paused) MainLayout.paused = true;
			else MainLayout.paused = false;
			
		}

	}

	void printRebootButton () {

		/*
	 	 * Reboot button
	 	 */ 
		if (GUI.Button (new Rect (
			ScreenVariables.WIDTH * 0.15f + ScreenVariables.ANCHO_BUTTON * 0.01f + ScreenVariables.OFFSET, 
			(ScreenVariables.HEIGHT),
			ScreenVariables.WIDTH_BUTTON, 
			ScreenVariables.HEIGHT_BUTTON), "Reiniciar")) 
		{
			Application.LoadLevel (Application.loadedLevel);
		}

	}

	void printPauseDialog () {

		Texture2D originalButton = new GUIStyle("button").normal.background;
		if (pauseSkin) GUI.skin = pauseSkin;

		/*
		 * Pause Dialog
		 */ 
		GUI.Box (new Rect (ScreenVariables.WIDTH * 0.1f, ScreenVariables.HEIGHT * 0.7f, ScreenVariables.WIDTH * 0.8f, ScreenVariables.HEIGHT * 0.5f), "Menu de pausa.");
		GUI.skin.GetStyle ("button").normal.background = originalButton;

		printContinueButton ();
		printRebootButton ();

	}

	void OnGUI() {

		if (MainLayout.paused) {

			GUI.depth = 2;
			printPauseDialog();

		}
	
	}

}
