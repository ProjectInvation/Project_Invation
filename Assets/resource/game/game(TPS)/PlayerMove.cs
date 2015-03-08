using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {
	private Vector3 pos;
	private Vector3 rot;
	private Vector3 Front;
	private Vector3 Up;
	private Vector3 Right;

	// Use this for initialization
	void Start () {
		pos.x = 0.0f;
		pos.y = 1.0f;
		pos.z = 0.0f;

		this.transform.position = pos;
	}
	
	// Update is called once per frame
	void Update () {
		Front = this.transform.forward;
		Up = this.transform.up;
		Right = this.transform.right;

		//AllVector is Normalize
		Front.Normalize();
		Up.Normalize();
		Right.Normalize();

		if (Input.GetKey (KeyCode.W)) 
		{
			pos = pos + (Front / 5);
		}else if(Input.GetKey(KeyCode.S)){
			pos = pos + -(Front / 5);
		}

		if (Input.GetKey (KeyCode.D)) {
			rot.y++;
		} else if (Input.GetKey (KeyCode.A)) {
			rot.y--;
		} else {
			rot.y = 0;
		}

		this.transform.Rotate(rot);
		this.transform.position = pos;
	}
}
