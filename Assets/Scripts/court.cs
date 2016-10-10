using UnityEngine;
using System.Collections;

public class court : MonoBehaviour {
	private bool hit = false;
	private GameObject col;

	void OnCollisionEnter(Collision collision){
		//床にボールが落ちた時、ボールのPrefabを消して新規に作成.
		if (collision.gameObject.tag == "Ball") {
			hit = true;
			col = collision.gameObject;
		}
	}
	void Update(){
		if (hit == true) {
			Destroy (col);
			GameManager.addBall ();
			hit = false;
		}
	}
}