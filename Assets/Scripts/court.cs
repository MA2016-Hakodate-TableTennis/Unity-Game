using UnityEngine;
using System.Collections;

public class court : MonoBehaviour {
	private bool hit = false;
	private GameObject collider;

	void OnCollisionEnter(Collision collision){
		//床にボールが落ちた時、ボールのPrefabを消して新規に作成.
		if (collision.gameObject.tag == "Ball") {
			hit = true;
			collider = collision.gameObject;
		}
	}
	void Update(){
		if (hit == true) {
			Destroy (collider);
			GameManager.addBall ();
			hit = false;
		}
	}
}