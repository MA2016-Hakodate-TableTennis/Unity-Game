using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	// Use this for initialization
	void Start () {
		addBall ();
	}
	public static void addBall(){
		GameObject ball = Ball.AddBall (new Vector3 (0, 2, -2.5f));
		ball.GetComponent<Rigidbody> ().AddForce (Vector3.forward * 7, ForceMode.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
