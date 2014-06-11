using UnityEngine;
using System.Collections;

public class MovCursor : MonoBehaviour {
	
	public float rota;
	public float rotaCam;
	Vector3 movement;
	
	void Start () {
		rota = 4.0f;
		rotaCam = 10.0f;
		movement = Vector3.zero;
	}

	void Update () {

		// l-> girto der, k -> giro izq.
		if (Input.GetKey("k")){
			this.transform.Rotate(0, -rotaCam * Time.deltaTime,0);
		}
		
		if (Input.GetKey ("l")){
			this.transform.Rotate(0, rotaCam * Time.deltaTime, 0);
		}
	}
}
