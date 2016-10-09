using UnityEngine;
using System.Collections;

public class Racket : MonoBehaviour {
	bool flg = false;
	Vector3 initialPos;

	private bool hit = false;
	private GameObject col;

	// Use this for initialization
	void Start () {
		initialPos = transform.position;
	}

	void OnTriggerEnter(Collider collider){
		//パッドにボールが当たった時、ボールの加速度を逆転させる.
		if (collider.gameObject.tag == "Ball") {
			hit = true;
			col = collider.gameObject;
		}
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space)) {
			flg = true;
			Debug.Log ("Space");
		}
		if (flg == true) {
			transform.position = new Vector3 (transform.position.x, transform.position.y, initialPos.z - Mathf.PingPong (Time.time,1));
		}
		if (Mathf.PingPong (Time.time, 1) <= 0.1f) {
			flg = false;
		}
		if (hit == true) {
			//-col.GetComponent<RigidBody>().zを加算することで、現在の速度を相殺できる.
			col.GetComponent<Rigidbody> ().AddForce (new Vector3 (0, -2, -col.GetComponent<Rigidbody>().velocity.z - 5), ForceMode.Impulse);
			hit = false;
		}
	}
}
