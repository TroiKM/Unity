using UnityEngine;
using System.Collections;

public class InterfazUsuario : MonoBehaviour {

	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{

		GUI.Box(new Rect(Screen.width/2 - 150, Screen.height/2, 300, 300), "");

		GUI.Button(new Rect(Screen.width/2 - 200, Screen.height/2,85,25), "BOTON1");
	//	GUI.Button(new Rect(,85,25), "BOTON2");
	//	GUI.Button(new Rect(,85,25), "BOTON3");
	}
}
