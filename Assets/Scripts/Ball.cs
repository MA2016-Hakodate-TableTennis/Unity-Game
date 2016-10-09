using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public static GameObject AddBall(Vector3 vec){
		// プレハブを取得
		GameObject prefab = (GameObject)Resources.Load ("Prefabs/Ball");
		// プレハブからインスタンスを生成
		return Instantiate (prefab, vec, Quaternion.identity) as GameObject;
	}
}
