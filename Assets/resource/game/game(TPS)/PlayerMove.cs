using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {
	private Vector3 pos;
	private Quaternion rot;
	private Vector3 Front;
	private Vector3 Up;
	private Vector3 Right;
	private GameObject MainCamera;


	// Use this for initialization
	void Start () {
		pos.x = 0.0f;
		pos.y = 1.0f;
		pos.z = 0.0f;

		rot.x = 0.0f;
		rot.y = 0.0f;
		rot.z = 0.0f;
		rot.w = 1.0f;

		this.transform.position = pos;
		MainCamera = GameObject.Find ("Main Camera");
	}
	
	// Update is called once per frame
	void Update () {
		Front = MainCamera.transform.forward;
		Up = this.transform.up;
		Right = MainCamera.transform.right;

		Front.y = 0;
		Right.y = 0;

		//AllVector is Normalize
		Front.Normalize();
		Up.Normalize();
		Right.Normalize();

		if (Input.GetKey (KeyCode.W)) 
		{
			pos = pos + (Front / 5);
			this.transform.forward = Front;
		}else if(Input.GetKey(KeyCode.S)){
			pos = pos + -(Front / 5);
			this.transform.forward = -Front;
		}

		if (Input.GetKey (KeyCode.D)) {
			pos = pos + (Right / 5);
			this.transform.forward = Right;
		} else if (Input.GetKey (KeyCode.A)) {
			pos = pos + -(Right / 5);
			this.transform.forward = -Right;

		}

		this.transform.position = pos;
	}
}
