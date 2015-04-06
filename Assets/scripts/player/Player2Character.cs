using UnityEngine;
using System.Collections;

public class Player2Character : MonoBehaviour {
	public int ObjNum;						//Enemy Object Num

	private Vector3 PlayerRot;				//Player Rotation Speed
	public float MoveSpeed = 0.05f; 		//Max Move Speed
	private Vector3 Axis;					//Enemy to Player Distance And Axis

	public readonly float Maxspeed = 3.0f;	//Max Rotation Speed;
	private Vector3 PlayerPosDest;			//Player Pos is Dest;

	private int Life = 100;
	private int point;
	private int FirstPoint = 1000;

	private int Count = 0;
	private int TurnCount = 6;
	private float TurnRot;

	private GameObject [] Enemys;				//Enemy of GameObjects

	// Use this for initialization
	void Start () {
		//InitSet!
		PlayerPosDest = this.transform.position;
		Enemys = new GameObject[ObjNum];
		point = FirstPoint;
		TurnRot = 180 / TurnCount;
	}
	
	// Update is called once per frame
	void Update () {
		if(GameObject.Find("NetworkMenu").GetComponent<NetworkMenu>().PlayerID==2)
		{
			GetComponent<NetworkView> ().RPC ("PlayerRpc", RPCMode.All);
		}
	}

	[RPC]
	public void PlayerRpc()
	{
		for (int i = 0; i < ObjNum; i++) {
			Enemys[i] = GameObject.Find("Enemy_" + (i+1));
		}
		
		//FrontVector is set this forward
		Vector3 PlayerFront = this.transform.forward;
		PlayerFront.Normalize();
		PlayerFront.y = 0;
		PlayerFront.x = 0;

		if (GetComponent<NetworkView> ().isMine) 
		{
			//Input key move and rot 
			if (Input.GetKey (KeyCode.W) || Input.GetAxisRaw ("Vertical") < 0) 
			{
				//PlayerPosDest += (PlayerFront / MoveSpeed);
				this.transform.Translate (0, 0, MoveSpeed);
			} 

			else if (Input.GetKey (KeyCode.S) || Input.GetAxisRaw ("Vertical") > 0) 
			{
				//PlayerPosDest += -(PlayerFront / MoveSpeed);
				this.transform.Translate (0, 0, -MoveSpeed);
			}
		
			if (Input.GetKey (KeyCode.A) || Input.GetAxisRaw ("Horizontal") < 0)
			{
				PlayerRot.y -= 0.1f;
				if (PlayerRot.y <= -this.Maxspeed)
				{
					PlayerRot.y = -this.Maxspeed;
				}
			}
			else if (Input.GetKey (KeyCode.D) || Input.GetAxisRaw ("Horizontal") > 0) {
				PlayerRot.y += 0.1f;
				if (PlayerRot.y >= this.Maxspeed) 
				{
					PlayerRot.y = this.Maxspeed;
				}
			} 
			else 
			{
				PlayerRot.y = 0;
			}
		
			//Quick turn
			if (Input.GetKeyDown (KeyCode.Q) /*|| Input.GetButtonDown("L2")*/)
			{
				Count = TurnCount;
			}
			if (Count > 0)
			{
				Count--;
				PlayerRot.y += TurnRot;
			}
		
			//Inertia Move 
			//this.transform.Translate((PlayerPosDest - this.transform.position) * 0.2f);
			this.transform.Rotate (PlayerRot);
		
			//Atack style Move
			int count = 0;
			for (int i = 0; i < this.ObjNum; i++) {
				if (Enemys [i] == null) {
					count++;
					continue;
				}
				if (i == count) {
					Axis = Enemys [i].transform.position - this.transform.position;
				} else {
					Vector3 CurAxis = Enemys [i].transform.position - this.transform.position;
					if (CurAxis.sqrMagnitude < this.Axis.sqrMagnitude) {
						Axis = CurAxis;
					}
				}
			
				Axis.y = 0;
			}
		
			if (Input.GetMouseButton (1) || Input.GetButton ("L1")) {
				if (PlayerRot.y == 0) {
					this.transform.forward += (Axis - this.transform.forward) * 0.2f;
				}
			
				MoveSpeed = 0.03f;
			} else {
				MoveSpeed = 0.03f;
			}
		
		}
		//Vector3 Up = new Vector3(0,1,0);
		//this.transform.up = Up;
	}
}
