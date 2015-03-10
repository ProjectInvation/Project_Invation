using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {
	private GameObject Player;		//PlayerObject:Data
	private Vector3 PFront;			//PlayerObject:FrontVector
	private Vector3 PUp;			//PlayerObject:UpVector
	private Vector3 PRight;			//PlayerObject:RightVector

	public float Distance = 1.5f;
	public float cameraRotationSpeed = 3.0f;

	float rotationX = 0;
	float rotationY = 0;

	readonly float MaxYAngle = 60;
	readonly float MinYAngle = -60;

	// Use this for initialization
	void Start () {
		//PlayerObject:data get
		Player = GameObject.Find ("Player");
		//Behind camera Test
		//AllVector: data get
		PFront = Player.transform.forward;
		PUp = Player.transform.up;
		PRight = Player.transform.right;
		
		//AllVector is Normalize
		PFront.Normalize();
		PUp.Normalize();
		PRight.Normalize();
	}
	
	// Update is called once per frame
	void Update () {




		this.transform.LookAt(Player.transform.position + (PUp * 1.5f));


		//Camera mouse move test

		//Mouse Move Speed get
		float mouseX = Input.GetAxis ("Mouse X");
		float mouseY = Input.GetAxis ("Mouse Y");

		//Move speed on Camera rotation
		this.rotationX += mouseX * cameraRotationSpeed;
		this.rotationY += mouseY * cameraRotationSpeed;

		//Limit of Vector Y
		this.rotationY = Mathf.Clamp (this.rotationY, MinYAngle, MaxYAngle);

		//PFront:Vector of Rotation
		Vector3 CameraRot = PFront;
		CameraRot = Quaternion.Euler (-rotationY, rotationX, 0) * CameraRot;
		CameraRot *= Distance;

		//The position of the camera is set behind the player
		this.transform.position = Player.transform.position + -CameraRot + (PUp * 1.5f);

	/*Quaternion.AngleAxis (rotationX, Vector3.up)
								* Quaternion.AngleAxis (-rotationY, Vector3.right)
								* Quaternion.identity;*/
	}
}
