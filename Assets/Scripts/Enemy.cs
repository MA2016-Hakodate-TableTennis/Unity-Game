using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	private bool hit = false;
	private GameObject col;
	// Use this for initialization
	void Start () {
	
	}
	void OnTriggerEnter(Collider collider){
		//パッドにボールが当たった時、ボールの加速度を逆転させる.
		if (collider.gameObject.tag == "Ball") {
			col = collider.gameObject;
			hit = true;
		}
	}
	// Update is called once per frame
	void Update () {
		// Update is called once per frame
		if (hit == true) {
			//-col.GetComponent<RigidBody>().zを加算することで、現在の速度を相殺できる.
			col.GetComponent<Rigidbody> ().AddForce (new Vector3 ( -col.GetComponent<Rigidbody>().velocity.x, -2, -col.GetComponent<Rigidbody>().velocity.z + 5), ForceMode.Impulse);
			hit = false;
		}	
	}
}
