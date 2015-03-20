using UnityEngine;
using System.Collections;

public class PlayerCharacter : MonoBehaviour {
	private Vector3 PlayerRot;				//Player Rotation Speed
	public float MoveSpeed = 10.0f; 		//Max Move Speed
	private Vector3 Axis;					//Enemy to Player Distance And Axis

	public readonly float Maxspeed = 3.0f;	//Max Rotation Speed;
	private Vector3 PlayerPosDest;			//Player Pos is Dest;

	private GameObject Enemy;				//Enemy of GameObject

	// Use this for initialization
	void Start () {
		//InitSet!
		PlayerPosDest = this.transform.position;
		Enemy = GameObject.Find ("EnemyObject");
	}
	
	// Update is called once per frame
	void Update () {
		//FrontVector is set this forward
		Vector3 PlayerFront = this.transform.forward;
		PlayerFront.Normalize();
		PlayerFront.y = 0;
		PlayerFront.x = 0;

		//Input key move and rot 
		if (Input.GetKey (KeyCode.W) || Input.GetAxisRaw("Vertical") > 0) {
			//PlayerPosDest += (PlayerFront / MoveSpeed);
			this.transform.Translate(0,0,0.03f);
		} else if (Input.GetKey (KeyCode.S) || Input.GetAxisRaw("Vertical") < 0) 
		{
			//PlayerPosDest += -(PlayerFront / MoveSpeed);
			this.transform.Translate(0,0,-0.03f);
		}

		if (Input.GetKey (KeyCode.A) || Input.GetAxisRaw("Horizontal") < 0) {
			PlayerRot.y -= 0.1f;
			if (PlayerRot.y <= -this.Maxspeed) {
				PlayerRot.y = -this.Maxspeed;
			}
		} else if (Input.GetKey (KeyCode.D) || Input.GetAxisRaw("Horizontal") > 0) {
			PlayerRot.y += 0.1f;
			if (PlayerRot.y >= this.Maxspeed) {
				PlayerRot.y = this.Maxspeed;
			}
		} else {
			PlayerRot.y = 0;
		}

		//Inertia Move 
		//this.transform.Translate((PlayerPosDest - this.transform.position) * 0.2f);
		this.transform.Rotate (PlayerRot);

		//Atack style Move
		if (Input.GetMouseButtonDown (1) || Input.GetButton("L1")) {
			//Close Axis set
			Axis = Enemy.transform.position - this.transform.position;
			Axis.y = 0;
		}
		if(Input.GetMouseButton(1)|| Input.GetButton("L1")){
			if(PlayerRot.y == 0){
				this.transform.forward += (Axis - this.transform.forward) * 0.2f;
			}

			MoveSpeed = 30.0f;
		} else {
			MoveSpeed = 10.0f;
		}

		//Vector3 Up = new Vector3(0,1,0);
		//this.transform.up = Up;
	}
}
