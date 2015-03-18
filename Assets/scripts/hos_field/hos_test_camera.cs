using UnityEngine;
using System.Collections;

public class hos_test_camera : MonoBehaviour {

	Camera Camera1;//カメラ1
	Camera Camera2;//カメラ2

	// Use this for initialization
	void Start () {
		Camera1 = GameObject.Find("Camera1").GetComponent<Camera>();
		Camera2 = GameObject.Find ("Camera2").GetComponent<Camera> ();
		
		Camera2.enabled = false;

	}
	
	// Update is called once per frame
	void Update () {
		// Spaceキーで切り替え
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if(Camera1.enabled){
				Camera1.enabled = false;
				Camera2.enabled = true;
			}else{
				Camera1.enabled = true;
				Camera2.enabled = false;
			}
		} 
	}
}
