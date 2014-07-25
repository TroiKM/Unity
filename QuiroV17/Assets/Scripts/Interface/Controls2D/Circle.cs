/* Company: Ludopia
 * Class: Circle
 * Description:
 * 		Class that represents a textured circle
 * 
 */

using UnityEngine;
using System.Collections;

public class Circle : MonoBehaviour {

	public Vector2 center;
	public float radius;
	public float diameter;
	public Texture2D texture;

	public Circle () {

	}

	public Circle (Vector2 center, float radius, Texture2D texture) {
		this.center = center;
		this.radius = radius;
		this.diameter = 2.0f * radius;
		this.texture = texture;
	}

	public Rect rectangularArea () {
		return new Rect (center.x, center.y, diameter, diameter);
	}

	public bool contains (Vector2 region) {
		return this.rectangularArea().Contains(region);
	}

	public void print () {
		GUI.DrawTexture(this.rectangularArea(), texture);
	}

}
