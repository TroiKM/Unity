using UnityEngine;
using System.Collections;

public class Atroscopio : MonoBehaviour {

	public float anguloVision;
	public GameObject camara;

	// Use this for initialization
	void Start () {
		anguloVision = 0.0f;
		prepararAnguloVision ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void prepararAnguloVision() {
		camara = GameObject.Find ("MainCamera");
		Vector3 rotacionCamara = camara.transform.rotation.eulerAngles;
		rotacionCamara.x = anguloVision;
		camara.transform.Rotate (rotacionCamara);
	}
}
