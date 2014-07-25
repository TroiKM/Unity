/* Company: Ludopia
 * Class:  DraggableCircle
 * Description:
 * 		Class that represents a draggable Circle
 * 
 */

using UnityEngine;
using System.Collections;

/*
 * Extends Circle, wich extends MonoBehaviour
 */ 
public class DraggableCircle : Circle {

	public DraggableCircle (Vector2 center, float radius, Texture2D texture) {
		this.center = center;
		this.radius = radius;
		this.diameter = 2.0f * radius;
		this.texture = texture;
	}

}
