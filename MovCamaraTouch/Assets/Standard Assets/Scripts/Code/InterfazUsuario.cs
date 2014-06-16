using UnityEngine;
using System.Collections;

public class InterfazUsuario : MonoBehaviour {

	public GUISkin myGui = null;
	public GUISkin artro = null;
	public Texture2D check = null;
	public Texture2D edit = null;
	public Texture2D question = null;

	void Update () 
	{
	
	}

	void OnGUI()
	{
		if (myGui)
		{
			GUI.skin = myGui;
		}

		GUI.Box(new Rect(Screen.width/2 - 150, Screen.height/2, 300, 300), "");
		GUI.Box(new Rect(Screen.width/2 - 150, Screen.height/2, 300, 40), "");

		GUI.Button(new Rect(Screen.width/2 - 145, Screen.height/2 + 5,95,30), edit);
		GUI.Button(new Rect(Screen.width/2 - 47, Screen.height/2 + 5,95,30), question);
		GUI.Button (new Rect (Screen.width / 2 + 50, Screen.height / 2 + 5, 95, 30), check);

		if (artro)
		{
			GUI.skin = artro;
		}

		GUI.Box(new Rect(Screen.width/2 - 145, Screen.height/2 + 150, 42, 42), "");
		GUI.Button(new Rect(Screen.width/2 + 103, Screen.height/2 + 150, 42, 42), "");
	}
}
