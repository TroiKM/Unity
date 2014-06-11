using UnityEngine;
using System.Collections;

public class CollisionCamera : MonoBehaviour
{
	void OnTriggerStay(){
		Debug.Log("Hit the wall");
	}
}