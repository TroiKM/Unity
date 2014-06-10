using UnityEngine;
using System.Collections;

public class MovPunta : MonoBehaviour {

	public float rotaCam;

	// Use this for initialization
	void Start () {
	
				rotaCam = 10;
	}
	
	// Update is called once per frame
	void Update () {
	
		// l-> girto der, k -> giro izq.
		if (Input.GetKey("k"))
			this.transform.Rotate(0, 0, -rotaCam * Time.deltaTime);
		if (Input.GetKey ("l"))
			this.transform.Rotate(0, 0, rotaCam * Time.deltaTime);

	}
}
