using UnityEngine;
using System.Collections;

public class fix_camera_manager : MonoBehaviour
{
	private const int FLOOR_FIST  =0;
	private const int FLOOR_CENTER=1;
	private const int FLOOR_LEFT  =2;
	private const int FLOOR_RIGHT =3;
	private const int FLOOR_GOAL  =4;

	private int now_floor;


	//Camera Objects
	GameObject obj_fist_floor_cam;
	GameObject obj_center_floor_cam;
	GameObject obj_left_floor_cam;
	GameObject obj_right_floor_cam;
	GameObject obj_goal_floor_cam;

	// Use this for initialization
	void Start ()
	{
		obj_fist_floor_cam  =GameObject.Find("FastFloorCamera");
		obj_center_floor_cam=GameObject.Find("CenterFloorCamera");
		obj_left_floor_cam  =GameObject.Find("LeftFloorCamera");
		obj_right_floor_cam =GameObject.Find("RightFloorCamera");
		obj_goal_floor_cam  =GameObject.Find("GoalFloorCamera");

		obj_fist_floor_cam.SetActive(true);
		obj_center_floor_cam.SetActive(false);
		obj_left_floor_cam.SetActive(false);
		obj_right_floor_cam.SetActive(false);
		obj_goal_floor_cam.SetActive(false);

		now_floor=FLOOR_FIST;
	
	}

	// Update is called once per frame
	void Update ()
	{

	}

	public void ChangeCam(int Cam)
	{
		switch(now_floor)
		{
		case FLOOR_FIST:
			obj_fist_floor_cam.SetActive(false);
			break;
				
		case FLOOR_CENTER:
			obj_center_floor_cam.SetActive(false);
			break;
				
		case FLOOR_LEFT:
			obj_left_floor_cam.SetActive(false);
			break;
				
		case FLOOR_RIGHT:
			obj_right_floor_cam.SetActive(false);
			break;
				
		case FLOOR_GOAL:
			obj_goal_floor_cam.SetActive(false);
			break;
		}

		if(now_floor==FLOOR_CENTER)
		{
			switch(Cam)
			{
			case FLOOR_FIST:
				obj_fist_floor_cam.SetActive(true);
				now_floor=FLOOR_FIST;
				break;

			case FLOOR_LEFT:
				obj_left_floor_cam.SetActive(true);
				now_floor=FLOOR_LEFT;
				break;
				
			case FLOOR_RIGHT:
				obj_right_floor_cam.SetActive(true);
				now_floor=FLOOR_RIGHT;
				break;
				
			case FLOOR_GOAL:
				obj_goal_floor_cam.SetActive(true);
				now_floor=FLOOR_GOAL;
				break;
			}
		}

		else
		{
			obj_center_floor_cam.SetActive(true);
			now_floor=FLOOR_CENTER;
		}
	}

}