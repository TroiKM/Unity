/* Company: Ludopia
 * Class: ArrowSlider
 * Description:
 * 		Class that represents a slider with personalized behaviour and texture 
 * 
 */

using UnityEngine;
using System.Collections;

public class ArrowSlider : MonoBehaviour {

	public Vector2 position;
	public Vector2 size;
	public Texture2D texture;

	public ArrowSlider () {

	}

	public ArrowSlider (Vector2 position, Vector2 size, Texture2D texture) {
		this.position = position;
		this.size = size;
		this.texture = texture;
	}

	public Rect area () {
		return new Rect (position.x, position.y, size.x, size.y);
	}

	public void print () {
		GUI.DrawTexture(this.area(), texture);
	}

	public bool contains (Vector2 region) {
		return this.area().Contains(region);
	}
}
