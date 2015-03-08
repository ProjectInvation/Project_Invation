using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {
	private GameObject Player;		//PlayerObject:Data
	private Vector3 PFront;			//PlayerObject:FrontVector
	private Vector3 PUp;			//PlayerObject:UpVector
	private Vector3 PRight;			//PlayerObject:RightVector

	// Use this for initialization
	void Start () {
		//PlayerObject:data get
		Player = GameObject.Find ("Player");

	}
	
	// Update is called once per frame
	void Update () {
		//AllVector: data get
		PFront = Player.transform.forward;
		PUp = Player.transform.up;
		PRight = Player.transform.right;

		//The direction of the camera is player direction.
		this.transform.forward = PFront;

		//AllVector is Normalize
		PFront.Normalize();
		PUp.Normalize();
		PRight.Normalize();

		//The position of the camera is set behind the player
		this.transform.position = Player.transform.position + -PFront + (PUp * 1.5f) + (PRight * 0.35f);

	}
}
