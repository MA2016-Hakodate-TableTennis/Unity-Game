using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class transitionBtn : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void transition(){
		SceneManager.LoadScene("gameScene");
	}
}
