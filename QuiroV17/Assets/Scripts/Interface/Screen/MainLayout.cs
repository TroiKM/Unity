/* Company: Ludopia
 * Class:  MainLayout
 * Description:
 * 		Class that manage the Main Layout
 * 
 */

using UnityEngine;
using System.Collections.Generic;
using System;
using System.Timers;

public class MainLayout : MonoBehaviour {

	/*
	 * GUIS
	 */ 
	public Texture2D check = null;
	public Texture2D edit = null;
	public Texture2D question = null;
	public Texture2D exit = null;
	public Texture2D reboot = null;
	public Texture2D pause = null;
	public Texture2D arthro = null;

	public Camera cam1;
	public static Camera cam2;
	public Camera cam3;
	/*
	 * Timers, targets, collisions
	 */ 
	private float timer;
	private float rounded;
	public static int mins = 0;
	public static bool paused = false;
	public static bool result = false;
	public static string time;
	public static bool arthroscope = false;

	// Use this for initialization
	void Start () {
	
		paused = false;
		mins = 0;
		result = false;
		arthroscope = false;
		cam2 = Camera.main;
		cam1.enabled = true;
		cam2.enabled = false;
		cam3.enabled = false;
	}

	void manageTimers () {

		if (!paused) { 
			/*
			 * Time
			 */
			timer += Time.deltaTime;
			rounded = (float)(Math.Round((double)timer, 0));
			if ((mins >= 10) && (rounded >= 10))
				time = "0:" + mins.ToString() + ":" + rounded.ToString();
			else if (rounded >= 10)
				time = "0:0" + mins.ToString() + ":" + rounded.ToString();
			else
				time = "0:0" + mins.ToString() + ":0" + rounded.ToString();
			if (rounded > 59) {
				timer = 0.0f;
				mins = mins + 1;
			}
		}

	}
	
	// Update is called once per frame
	void Update () {
		if (MainLayout.cam2.enabled) {
			manageTimers ();
		} else {
			timer = 0.0f;
			mins = 0;
		}
	}

	void printLabels () {
		/*
		 * Time's label.
		 */ 
		GUI.Label(new Rect(0, 0, ScreenVariables.WIDTH, 120), "Tiempo: " + time + ".");
		/*
		 * Target's label.
		 */ 
		GUI.Label(new Rect(0.69f * ScreenVariables.WIDTH, ScreenVariables.HEIGHT * 0.85f, ScreenVariables.WIDTH, 120), "Objetivos: " + Targets.seenAmountTargets + " de " + Targets.amountTargets +".");
		/*
		 * Collision's label.
		 */ 
		GUI.Label(new Rect(0, ScreenVariables.HEIGHT * 0.85f, ScreenVariables.WIDTH, 120), "Num. colisiones: " + Collisions.amountCollisions + ".");
		
	}

	void printBasicButtons () {

		/*
		 * Reboot button
		 */ 
		if (GUI.Button(new Rect(3.2f * ScreenVariables.WIDTH / 4 - (ScreenVariables.WIDTH * 0.2f), 0, ScreenVariables.WIDTH * 0.2f, Screen.height / 14), reboot))
		{
			Application.LoadLevel(Application.loadedLevel);
		}
		
		/*
		 * Pause button
		 */ 
		if (GUI.Button(new Rect(3.2f * ScreenVariables.WIDTH / 4 - 2 * (ScreenVariables.WIDTH * 0.2f), 0, ScreenVariables.WIDTH * 0.2f, Screen.height / 14), pause))
		{
			paused = !paused;
		}
		
		/*
		 * Exit button
		 */ 
		if (GUI.Button(new Rect(3.2f * ScreenVariables.WIDTH / 4, 0,ScreenVariables. WIDTH * 0.2f, Screen.height / 14), exit))
		{
			Application.Quit();
		}

	}

	void printLowerSideScreen () {

		/* 
		 * Lower Box
		 */	
		GUI.Box(new Rect(0, ScreenVariables.HEIGHT, ScreenVariables.WIDTH, ScreenVariables.HEIGHT), "");
		
		/*
		 * Main buttons space box
		 */ 
		GUI.Box(new Rect(0, ScreenVariables.HEIGHT, ScreenVariables.WIDTH, ScreenVariables.HEIGHT*0.15f), "");
		
		if (!paused) {
			
			/*
			 * Edit button
			 */ 
			GUI.Button(new Rect(ScreenVariables.ANCHO_BUTTON * 0.01f + ScreenVariables.OFFSET, 
			                    (ScreenVariables.HEIGHT + (ScreenVariables.DIST_BUTTON * 0.01f)),
			                    ScreenVariables.WIDTH_BUTTON, 
			                    ScreenVariables.HEIGHT_BUTTON), edit);
			/*
			 * Question button
			 */ 
			GUI.Button(new Rect(ScreenVariables.ANCHO_BUTTON +ScreenVariables. ANCHO_BUTTON * 0.01f + ScreenVariables.OFFSET, 
			                    (ScreenVariables.HEIGHT + (ScreenVariables.DIST_BUTTON * 0.01f)),
			                    ScreenVariables.WIDTH_BUTTON, 
			                    ScreenVariables.HEIGHT_BUTTON), question);
			/*
			 * Check button
			 */ 
			if (
				GUI.Button(new Rect(2 * ScreenVariables.ANCHO_BUTTON + ScreenVariables.ANCHO_BUTTON * 0.01f + ScreenVariables.OFFSET, 
			                    (ScreenVariables.HEIGHT + (ScreenVariables.DIST_BUTTON * 0.01f)), 
			                    ScreenVariables.WIDTH_BUTTON, 
			                    ScreenVariables.HEIGHT_BUTTON), check)
				) 
			{
				ResultsMenu.showResultMenu = !ResultsMenu.showResultMenu;
			}

			/* 
			 * Athroscope menu 
			 */
			if (GUI.Button (new Rect (ScreenVariables.ANCHO_BUTTON * 0.01f + ScreenVariables.OFFSET, 
			                          (ScreenVariables.HEIGHT +ScreenVariables. HEIGHT_BUTTON * 5.3f + ScreenVariables.OFFSET), 
			                          ScreenVariables.WIDTH_BUTTON * 0.7f, 
			                          ScreenVariables.WIDTH_BUTTON* 0.5f), arthro))
			{
				arthroscope = !arthroscope;
			}
			
		}

	}

	/* Choose the level  */
	void printMainMenu() {

		//GUI.Box (new Rect (0,2.0f,ScreenVariables.WIDTH, ScreenVariables.HEIGHT * 2.0f),"");
		if (GUI.Button (new Rect (ScreenVariables.ANCHO_BUTTON, 
		                          ScreenVariables.HEIGHT, 
		                          ScreenVariables.WIDTH_BUTTON, 
		                          ScreenVariables.HEIGHT_BUTTON), "Nivel 1"))
		{
			cam1.enabled = false;
			cam2.enabled = true;
			cam3.enabled = true;
		}
		if (GUI.Button (new Rect (ScreenVariables.ANCHO_BUTTON, 
		                          ScreenVariables.HEIGHT + ScreenVariables.HEIGHT_BUTTON + ScreenVariables.OFFSET, 
		                          ScreenVariables.WIDTH_BUTTON, 
		                          ScreenVariables.HEIGHT_BUTTON), "Nivel 2"))
		{
			cam1.enabled = false;
			cam2.enabled = true;
			cam3.enabled = true;
		}
		if (GUI.Button (new Rect (ScreenVariables.ANCHO_BUTTON, 
		                          ScreenVariables.HEIGHT + (ScreenVariables.HEIGHT_BUTTON + ScreenVariables.OFFSET) *2.0f, 
		                          ScreenVariables.WIDTH_BUTTON, 
		                          ScreenVariables.HEIGHT_BUTTON), "Nivel 3"))
		{
			cam1.enabled = false;
			cam2.enabled = true;
			cam3.enabled = true;
		}
	}
	void OnGUI() {

		if (cam2.enabled)
		{
			GUI.depth = 4;
			GUI.skin.label.fontSize = (int)(Math.Round ((double)ScreenVariables.WIDTH * 0.04f, 0));

			printLabels ();
			printBasicButtons ();
			printLowerSideScreen ();
		} else { 
			printMainMenu();
			printBasicButtons ();
		}
	}

}
