/* Company: Ludopia
 * Class: ScreenVariables
 * Description:
 * 		Container class of some personalized screen variables
 * 
 */

using UnityEngine;
using System.Collections;

public class ScreenVariables : MonoBehaviour {

	/*
	 * We MUST iniziatlize this variables at this point; otherwise,
	 * it can be initialized with 0 befores Start() is executed, then, 
	 * other classes just acces corrupted values
	 */ 
	public static float WIDTH = Screen.width;
	public static float HEIGHT = Screen.height*0.5f;
	
	public static float DIST_BUTTON = HEIGHT *0.15f;
	public static float ANCHO_BUTTON = WIDTH * 0.33f;
	public static float OFFSET = 2.0f;
	
	public static float WIDTH_BUTTON = ANCHO_BUTTON * 0.99f;
	public static float HEIGHT_BUTTON = DIST_BUTTON * 0.99f;
	
}
