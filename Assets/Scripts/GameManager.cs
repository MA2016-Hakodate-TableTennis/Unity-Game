using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	// Use this for initialization
 	public GameObject racket;
	public static GameObject _ball;

	void Start () {
		racket.transform.position = new Vector3 (0, 2, -2.1f);

		addBall ();
	}
	public static void addBall(){
		GameObject ball = Ball.AddBall (new Vector3 (0, 2, -1.8f));
		ball.GetComponent<Rigidbody> ().AddForce (new Vector3(0,1,6), ForceMode.Impulse);
		_ball = ball;
	}

	// Update is called once per frame
	void Update () {
		float x = racket.transform.position.x + (_ball.transform.position.x - racket.transform.position.x) / 3;
		float y = racket.transform.position.y + (_ball.transform.position.y - racket.transform.position.y) / 3;

		racket.transform.position = new Vector3 (x,y,racket.transform.position.z);
	}
}
