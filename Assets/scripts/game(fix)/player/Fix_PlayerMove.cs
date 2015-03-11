using UnityEngine;
using System.Collections;

public class Fix_PlayerMove : MonoBehaviour 
{
	private const int FLOOR_FIST  =0;
	private const int FLOOR_CENTER=1;
	private const int FLOOR_LEFT  =2;
	private const int FLOOR_RIGHT =3;
	private const int FLOOR_GOAL  =4;

	//Player Movement Spd
	public float move_spd;
	public float rot_spd;
	public bool isGavity=true;
	public float gravity;
	private GameObject Player;
	private float angle;

	// Use this for initialization
	void Start ()
	{
		Player=GameObject.Find("Player_root");
		angle=0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		//Player Move
		PlayerMove();

		//Gravity
		if(isGavity)
		{
			Player.transform.Translate(0,gravity,0);
		}
	}

	void PlayerMove()
	{
		if(Input.GetKey(KeyCode.W))
		{
			Player.transform.Translate(0,0,move_spd);
		}
		
		if(Input.GetKey(KeyCode.S))
		{
			Player.transform.Translate(0,0,-move_spd);
		}
		
		if(Input.GetKey(KeyCode.A))
		{
			angle-=rot_spd;
			Player.transform.rotation= Quaternion.Euler(0,angle,0);
		}
		
		if(Input.GetKey(KeyCode.D))
		{
			angle+=rot_spd;
			Player.transform.rotation=Quaternion.Euler(0,angle,0);
		}
	}

	void OnTriggerEnter(Collider coll)
	{
		if(coll.tag==("col_fast")||coll.tag==("col_goal")||coll.tag==("col_left")||coll.tag==("col_right"))
		{
			switch(coll.tag)
			{
			case "col_fast":
				GameObject.Find("FixGame_manager").GetComponent<fix_camera_manager>().ChangeCam(FLOOR_FIST);
				break;

			case "col_goal":
				GameObject.Find("FixGame_manager").GetComponent<fix_camera_manager>().ChangeCam(FLOOR_GOAL);
				break;

			case "col_left":
				GameObject.Find("FixGame_manager").GetComponent<fix_camera_manager>().ChangeCam(FLOOR_LEFT);
				break;

			case "col_right":
				GameObject.Find("FixGame_manager").GetComponent<fix_camera_manager>().ChangeCam(FLOOR_RIGHT);
				break;
			}
		}
	}
}
