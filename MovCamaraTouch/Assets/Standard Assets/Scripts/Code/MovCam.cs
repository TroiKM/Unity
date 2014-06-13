using UnityEngine;
using System.Collections;

public class MovCam : MonoBehaviour {
	
	public float profMax;
	public float profMin;
	public float speed;
	public float rota;
	Vector3 ring = Vector3.zero;

	public float rotaCam;
	
	void Start() {

		// Inclinamos la camara 30 grados, tambien se puede
		//	 trabajar con 70 o 0 grados.
		Camera.main.transform.Rotate(-30*Time.deltaTime, 0, 0);
		speed = 0.5f;
		rota = 4.0f;
		rotaCam = 10;

		if (ring == Vector3.zero)
			ring = GameObject.FindGameObjectWithTag("Ring").transform.position;

		profMax = ring.z + 150.0f;
		profMin = ring.z + 2.0f;

	}


	void Update () {
		
		Vector3 movement = Vector3.zero;

		// w -> adelante, s -> atrás.
		if (Input.GetKey("w") && (this.transform.position.z <= profMax))
			movement.z++;
		if (Input.GetKey("s") && (this.transform.position.z >= profMin))
			movement.z--;

		this.transform.Translate(movement * speed, Space.Self);

		// a -> rot izq., d -> rot der.
		if (Input.GetKey("a"))
			this.transform.RotateAround(ring, Vector3.up, -rota * Time.deltaTime);	
		if (Input.GetKey("d"))
			this.transform.RotateAround(ring, Vector3.up, rota * Time.deltaTime);	

		// i -> arriba, 0 -> abajo.
		if 	(Input.GetKey("i"))
			this.transform.RotateAround(ring, Vector3.right, rota * Time.deltaTime);	
		if 	(Input.GetKey("o"))
			this.transform.RotateAround(ring, Vector3.right, -rota * Time.deltaTime);	

	}
}
