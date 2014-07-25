/* Company: Ludopia
 * Class:  Targets
 * Description:
 * 		Manager class of the game targets
 * 
 */

using UnityEngine;
using System.Collections;
using System.Linq;

public class Targets : MonoBehaviour {

	public Material unseenTargetMaterial;
	public Material seenTargetMaterial;

	public static int amountTargets;
	public static int seenAmountTargets;

	public float rayDistance;
	int war = 0;

	// Use this for initialization
	void Start () {
		rayDistance = 1.0f;
		seenAmountTargets = 0;
		amountTargets = 1;
		war = 0;
	}

	public GameObject createTarget (Vector3 position) {

		GameObject target = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		target.transform.position = position;
		target.transform.localScale = target.transform.localScale / 2;
		target.renderer.material = unseenTargetMaterial;
		return target;
		
	}

	/*
	 * range x = this.transform.position.x +- 10
	 * range y = [this.transform.position.y - 15, this.transform.position.y + 5]
	 * range z = [this.transform.position.z - 7, this.transform.position.z + 15]
	 */
	public void createLevel1 () {

		if (war == 0){
			war++;
			createTarget (new Vector3(this.transform.position.x - 1, this.transform.position.y - 8.0f , this.transform.position.z + Random.Range(-5.0f,2.0f) ));
			createTarget (new Vector3(this.transform.position.x + 1, this.transform.position.y - 8.0f , this.transform.position.z + Random.Range(-5.0f,2.0f) ));
			createTarget (new Vector3(this.transform.position.x, this.transform.position.y - 8.0f , this.transform.position.z + Random.Range(0.5f,2.5f) ));
			createTarget (new Vector3(this.transform.position.x, this.transform.position.y - 8.0f , this.transform.position.z + Random.Range(-4.0f,-5.0f) ));
			createTarget (new Vector3(this.transform.position.x + Random.Range(1.0f,2.5f), this.transform.position.y - 8.5f , this.transform.position.z + 0.5f));
			createTarget (new Vector3(this.transform.position.x + Random.Range(-1.0f,-2.5f), this.transform.position.y - 8.5f , this.transform.position.z + 0.5f));
		}
	}

	public GameObject createLevel2()
	{
		GameObject newCharacterGameObject = createTarget (new Vector3 (this.transform.position.x - 1, this.transform.position.y - 8.0f, this.transform.position.z + Random.Range (-5.0f, 2.0f)));

		AnimationClip theAnimation = animation.GetClip("Mov1");
		newCharacterGameObject.animation.AddClip(theAnimation, "Mov1");
		
		return newCharacterGameObject;
	}


	public void detectTargets () {

		/*
		 * Prepare de ray
		 */ 
		Ray [] rays = new Ray[5];
		rays[0] = MainLayout.cam2.ScreenPointToRay (new Vector3(Screen.width / 2, 3*Screen.height/4.0f, 0));
		rays[1] = new Ray(new Vector3(rays[0].origin.x - 0.5f, rays[0].origin.y - 0.5f, rays[0].origin.z), rays[0].direction);
		rays[2] = new Ray(new Vector3(rays[0].origin.x - 0.5f, rays[0].origin.y + 0.5f, rays[0].origin.z), rays[0].direction);
		rays[3] = new Ray(new Vector3(rays[0].origin.x + 0.5f, rays[0].origin.y - 0.5f, rays[0].origin.z), rays[0].direction);
		rays[4] = new Ray(new Vector3(rays[0].origin.x + 0.5f, rays[0].origin.y + 0.5f, rays[0].origin.z), rays[0].direction);

		/*
		 * Hit is an object hitted by the ray
		 */ 
		RaycastHit hit;
		for (int i = 0; i < 5; i++) {
			if (Physics.Raycast(rays[i], out hit, rayDistance)) {
				if (hit.collider.gameObject.name == "Sphere") {
					hit.collider.gameObject.name = "SeenSphere";
					hit.collider.gameObject.renderer.material = seenTargetMaterial;
					seenAmountTargets++;
				}
			}
			Debug.DrawRay (rays[i].origin, rays[i].direction * rayDistance, Color.green);
		}
		
	}
	
	// Update is called once per frame
	void Update () {

		if (MainLayout.level == 1 && war == 0)
		{
			amountTargets = 6;
			createLevel1 ();
		} 
		else if (MainLayout.level == 2)
		{
			amountTargets = 2;
		}
		else if (MainLayout.level == 3) 
		{
			amountTargets = 3;
		}

		detectTargets ();

	}

}
