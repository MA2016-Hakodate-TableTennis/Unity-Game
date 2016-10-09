using UnityEngine;
using System.Collections;
using NCMB;

public class GameManager : MonoBehaviour {
	// Use this for initialization
	void Start () {
		addBall ();
	}
	public static void addBall(){
		GameObject ball = Ball.AddBall (new Vector3 (0, 2, -3.5f));
		ball.GetComponent<Rigidbody> ().AddForce (new Vector3(0,1,6), ForceMode.Impulse);
		Debug.LogWarning("addBall");   // テストでワーニングログをコール
	}
	void OnNotificationReceived (NCMBPushPayload payload)
	{
		Debug.Log("OnNotificationReceived");
		Debug.Log("PushId : " + payload.PushId);
		Debug.Log("Massage : " + payload.Message);
		Debug.LogWarning("OnNotificationReceived");   // テストでワーニングログをコール
		Debug.LogWarning("PushId : " + payload.PushId);   // テストでワーニングログをコール
		Debug.LogWarning("Massage : " + payload.Message);   // テストでワーニングログをコール

		#if UNITY_ANDROID
		Debug.Log("Title : " + payload.Title);
		#endif
	}
	// Update is called once per frame
	void Update () {
		
	}
}
