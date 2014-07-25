using UnityEngine;
using System.Collections;

public class Interfaz : MonoBehaviour {

	// Variables para la interfaz grafica
	private float xIni;
	private float yIni;
	private float deltaY;
	private float deltaX;

	//Variables para el control de movimiento del artroscopio
	private float paso;
	private Vector3 posicion;

	//Variables para el control de la camara
	public GameObject camara;
	public float anguloVision;
	public Vector3 rotacionCamara;

	public float oldHorizontal;
	public float avanceSliderHorizontal;
	public float avanceSliderVertical;
	public float velocidad = 0.3f;
	
	// Use this for initialization
	void Start () {
		xIni = Screen.width / 5;
		yIni = Screen.height / 2 + Screen.height / 20;
		deltaY = Screen.height / 10;
		deltaX = xIni / 4;

		paso = 0.1f;
		posicion = this.transform.position;

		anguloVision = 0.0f;
		camara = GameObject.Find ("MainCamera");
		rotacionCamara = camara.transform.localEulerAngles;

		oldHorizontal = 0.0f;
		avanceSliderHorizontal = 0.0f;
		avanceSliderVertical = 0.0f;
	}

	float determinarVelocidad(float coordenadaActual, float coordenadaInicial) {
		int direccion = (coordenadaActual > coordenadaInicial) ? 1 : -1;
		return ( Mathf.Abs(coordenadaActual) * direccion * velocidad);
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = posicion;
	}

	void OnGUI() {
		// Boton reiniciar
		if(GUI.Button(new Rect(0, 0, Screen.width/4, Screen.height/14), "Reiniciar")) {
			Application.LoadLevel(Application.loadedLevel);
		}
		// Boton salir
		if(GUI.Button(new Rect(3*Screen.width/4, 0, Screen.width/4, Screen.height/14), "Salir")) {
			Application.Quit();
		}

		// Boton 0 grados (para mirar de frente a la rodilla el angulo inicial es 90, desde ahi se suman los otros angulos)
		if(GUI.RepeatButton(new Rect(0, yIni + 3.5f*deltaY, Screen.width/3, Screen.height/14), "0º")) {
			rotacionCamara.x = 90.0f;
			camara.transform.localEulerAngles = rotacionCamara;
		}
		// Boton 30 grados
		if(GUI.RepeatButton(new Rect(Screen.width / 3, yIni + 3.5f*deltaY, Screen.width/3, Screen.height/14), "30º")) {
			rotacionCamara.x = 120.0f;
			camara.transform.localEulerAngles = rotacionCamara;
		}
		// Boton 70 grados
		if(GUI.RepeatButton(new Rect(2.0f*Screen.width / 3, yIni + 3.5f*deltaY, Screen.width/3, Screen.height/14), "70º")) {
			rotacionCamara.x = 160.0f;
			camara.transform.localEulerAngles = rotacionCamara;
		}

	}
}
