using UnityEngine;
using System.Collections;
using SocketIO;


public class Racket : MonoBehaviour {
	bool flg = false;
	Vector3 initialPos;

	private bool hit = false;
	private GameObject col;
	private SocketIOComponent socket;

	// Use this for initialization
	void Start () {
		initialPos = transform.position;
		GameObject go = GameObject.Find("SocketIO");
		socket = go.GetComponent<SocketIOComponent>();

		socket.On("open", TestOpen);
		socket.On("error", TestError);
		socket.On("close", TestClose);

		// メッセージ受信を追加
		socket.On ("S_to_C_message", S_to_C_message);
		GetComponent<SphereCollider>().enabled = false;

	}
	// 追加関数
	public void S_to_C_message( SocketIOEvent e ){
		//データ受信部分
		Debug.Log("[SocketIO] C_to_S_message received: " + e.name + " " + e.data);
		flg = true;

	}

	public void TestOpen(SocketIOEvent e)
	{
		Debug.Log("[SocketIO] Open received: " + e.name + " " + e.data);
	}

	public void TestError(SocketIOEvent e)
	{
		Debug.Log("[SocketIO] Error received: " + e.name + " " + e.data);
	}

	public void TestClose(SocketIOEvent e)
	{	
		Debug.Log("[SocketIO] Close received: " + e.name + " " + e.data);
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
		if (flg == true) {
			GetComponent<SphereCollider>().enabled = true;
			transform.position = new Vector3 (transform.position.x, transform.position.y, initialPos.z - Mathf.PingPong (Time.time,1));
		}
		if (Mathf.PingPong (Time.time, 1) <= 0.1f) {
			GetComponent<SphereCollider>().enabled = false;
			flg = false;
		}
		if (hit == true) {
			//-col.GetComponent<RigidBody>().zを加算することで、現在の速度を相殺できる.
			col.GetComponent<Rigidbody> ().AddForce (new Vector3 (Random.Range(-1.0f,1.0f), -2, -col.GetComponent<Rigidbody>().velocity.z - 5), ForceMode.Impulse);
			//回転
			col.GetComponent<Rigidbody> ().AddTorque(10,0, 0,ForceMode.Force);
			hit = false;
		}
	}
}
