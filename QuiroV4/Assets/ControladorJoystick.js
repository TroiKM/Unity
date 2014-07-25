/*
 *
 */
#pragma strict

var joystick : Joystick;
var joystickIzquierda : Joystick;
var joystickArriba : Joystick;
var posicionInicialJoystick: Vector3;
var velocidad: float;
var posicionArtroscopio: Vector3;

function Start () {
	velocidad = 0.3f;
//	posicionInicialJoystick = joystick.transform.position;
//	posicionArtroscopio = this.transform.position;
}

function determinarVelocidad(coordenadaActual: float, coordenadaInicial: float) {
	var direccion = (coordenadaActual > coordenadaInicial) ? 1 : -1;
	return ( Mathf.Abs(coordenadaActual) * direccion * velocidad);
}

/*function restringirJoystick () {
	var posicion: Vector2 = joystick.position;
	if (posicion.x > 0.4f) posicion.x = 0.4f;
	if (posicion.x < -0.2f) posicion.x = -0.2f;
	if (posicion.y > 0.01) posicion.y = 0.01;
	if (posicion.y < -0.0001) posicion.y = -0.0001;
	joystick.position = posicion;
}


function Update () {

	//restringirJoystick();
	
	// Movimientos de rotacion del joystick del centro
	this.transform.Rotate(determinarVelocidad(joystick.position.y, posicionInicialJoystick.y), 0, 0);
	this.transform.Rotate(0, 0, determinarVelocidad(joystick.position.x, posicionInicialJoystick.x) * -1);
	
	// Movimientos de acercar y alejar del joystick de la izquierda
	posicionArtroscopio.z += (-1 * determinarVelocidad(joystickIzquierda.position.y,0));
	this.transform.position = posicionArtroscopio;
	
	// Movimientos de rotacion del jotstick de arriba
	this.transform.Rotate(0, -2 * determinarVelocidad(joystickArriba.position.x, 0), 0);
	
	// el artroscopio rota pero no la camara
	//if (movioJoy) 
	
	//this.transform.eulerAngles = new Vector3 ( 90.0f + determinarVelocidad(joystick.position.y, posicionInicialJoystick.y), 0, determinarVelocidad(joystick.position.x, posicionInicialJoystick.x) * -1);
	
	// Rotate around Y axis
	//transform.RotateAround(Vector3.up, Time.deltaTime * determinarVelocidad(joystick.position.y, posicionInicialJoystick.y));
 
	// Rotate around Z axis
	//transform.RotateAround(Vector3.left, Time.deltaTime * determinarVelocidad(joystick.position.x, posicionInicialJoystick.x) * -1);
	
	
	
	// Movimientos de rotacion del joystick izquierdo
	/*if (sliderIzquierda.position.y > 0 && sliderDerecha.position.y < 0) {
		if (Mathf.Abs(sliderIzquierda.position.y) < Mathf.Abs(sliderDerecha.position.y)) {
			this.transform.Rotate(0, -determinarVelocidad(sliderIzquierda.position.y, posicionInicialJoystickIzquierda.y), 0);		
		}
		else {
			this.transform.Rotate(0, -determinarVelocidad(sliderDerecha.position.y, posicionInicialJoystickDerecha.y), 0);		
		}
	} 
	if (sliderIzquierda.position.y < 0 && sliderDerecha.position.y > 0) {
		if (Mathf.Abs(sliderIzquierda.position.y) < Mathf.Abs(sliderDerecha.position.y)) {
			this.transform.Rotate(0, determinarVelocidad(sliderIzquierda.position.y, posicionInicialJoystickIzquierda.y), 0);		
		}
		else {
			this.transform.Rotate(0, determinarVelocidad(sliderDerecha.position.y, posicionInicialJoystickDerecha.y), 0);		
		}
	}*/
