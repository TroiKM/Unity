using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Interfaz01 : MonoBehaviour {
	
	public GUISkin myGui = null;
	public GUISkin artro = null;
	public Texture2D check = null;
	public Texture2D edit = null;
	public Texture2D question = null;
	// Hierarchy DRAG E DROP over var GUI Text in Inspector
	
	void OnGUI()
	{
		float WIDTH = Screen.width;
		float HEIGHT = Screen.height*0.5f;
		
		float DIST_BUTTON =  HEIGHT *0.15f;
		float ANCHO_BUTTON = WIDTH * 0.33f;
		float offset = 2.0f;
		
		float WIDTH_BUTTON = ANCHO_BUTTON * 0.99f;
		float HEIGHT_BUTTON = DIST_BUTTON * 0.99f;
		
		if (myGui)
			GUI.skin = myGui;
		
		// Espacio de la interfaz del usuario.
		GUI.Box(new Rect(0, HEIGHT, WIDTH, HEIGHT), "");
		
		// Espacio para botones principales de la aplicacion
		GUI.Box(new Rect(0, HEIGHT, WIDTH, HEIGHT*0.15f), "");
		
		// Boton edit.
		GUI.Button(new Rect(ANCHO_BUTTON * 0.01f + offset, 
		                    (HEIGHT + (DIST_BUTTON * 0.01f)),
		                    WIDTH_BUTTON, 
		                    HEIGHT_BUTTON), edit);
		// Boton question.
		GUI.Button(new Rect(ANCHO_BUTTON + ANCHO_BUTTON * 0.01f + offset, 
		                    (HEIGHT + (DIST_BUTTON * 0.01f)),
		                    WIDTH_BUTTON, 
		                    HEIGHT_BUTTON), question);
		// Boton edit.
		GUI.Button(new Rect(2 * ANCHO_BUTTON + ANCHO_BUTTON * 0.01f + offset, 
		                    (HEIGHT + (DIST_BUTTON * 0.01f)), 
		                    WIDTH_BUTTON, 
		                    HEIGHT_BUTTON), check);
		
		// Parte inferior de la aplicacion.
		
		/* Atroscopio. */
		if (artro)
			GUI.skin = artro;
		GUI.Button(new Rect(ANCHO_BUTTON * 0.01f + offset, 
		                    (HEIGHT + 5.7f * HEIGHT_BUTTON), 
		                    WIDTH_BUTTON, 
		                    HEIGHT_BUTTON), "0");
		
		GUI.Button(new Rect(ANCHO_BUTTON + ANCHO_BUTTON * 0.01f + offset,
		                    (HEIGHT + 5.7f * HEIGHT_BUTTON), 
		                    WIDTH_BUTTON, 
		                    HEIGHT_BUTTON), "30");
		
		GUI.Button(new Rect(2 * ANCHO_BUTTON + ANCHO_BUTTON * 0.01f + offset, 
		                    (HEIGHT + 5.7f * HEIGHT_BUTTON), 
		                    WIDTH_BUTTON, 
		                    HEIGHT_BUTTON), "70");
		/* Herramienta. */
	}
}
