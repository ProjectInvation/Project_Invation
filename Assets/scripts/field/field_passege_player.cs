using UnityEngine;
using System.Collections;

public class field_passege_player : MonoBehaviour {

	GameObject playerObj;
	Collider cameraBackUp;
	
	field_passege.CAMERA_NUM cameraNum;
	
	// Use this for initialization
	void Start () {
		cameraBackUp = null;
		playerObj=GameObject.Find("Army 01");
		cameraNum = field_passege.CAMERA_NUM.CAMERA_START;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.W))
		{
			playerObj.transform.Translate(0,0,0.1f);
		}	
		if(Input.GetKey(KeyCode.S))
		{
			playerObj.transform.Translate(0,0,-0.1f);
		}
		if(Input.GetKey(KeyCode.A))
		{
			playerObj.transform.Translate(0.1f,0,0f);
		}
		if(Input.GetKey(KeyCode.D))
		{
			playerObj.transform.Translate(-0.1f,0,0f);
		}
	}
	
	void OnTriggerExit(Collider collider)
	{
		if (collider.tag != ("beltHitObjFront") && collider.tag != ("beltHitObjCenter") && collider.tag != ("beltHitObjCenterLeft") && collider.tag != ("beltHitObjCenterRight") && collider.tag != ("beltHitObjBack") && collider.tag != ("beltHitObjBack2")) 
		{
			return;
		}
		
		switch (collider.tag) 
		{
		case "beltHitObjFront":
		{
			if(cameraNum==field_passege.CAMERA_NUM.CAMERA_START)
			{
				cameraNum=field_passege.CAMERA_NUM.CAMERA_FRONT;
			}
			else
			{
				cameraNum=field_passege.CAMERA_NUM.CAMERA_START;
			}
			break;
		}
		case "beltHitObjCenter":
		{
			if(cameraNum==field_passege.CAMERA_NUM.CAMERA_FRONT)
			{
				cameraNum=field_passege.CAMERA_NUM.CAMERA_CENTER;
			}
			else
			{
				cameraNum=field_passege.CAMERA_NUM.CAMERA_FRONT;
			}
			break;
		}
		case "beltHitObjCenterLeft":
		{
			if(cameraNum==field_passege.CAMERA_NUM.CAMERA_CENTER)
			{
				cameraNum=field_passege.CAMERA_NUM.CAMERA_CENTER_LEFT;
			}
			else
			{
				cameraNum=field_passege.CAMERA_NUM.CAMERA_CENTER;
			}
			break;
		}
		case "beltHitObjCenterRight":
		{
			if(cameraNum==field_passege.CAMERA_NUM.CAMERA_CENTER_LEFT)
			{
				cameraNum=field_passege.CAMERA_NUM.CAMERA_CENTER_RIGHT;
			}
			else
			{
				cameraNum=field_passege.CAMERA_NUM.CAMERA_CENTER_LEFT;
			}
			break;
		}
		case "beltHitObjBack":
		{
			if(cameraNum==field_passege.CAMERA_NUM.CAMERA_BACK)
			{
				cameraNum=field_passege.CAMERA_NUM.CAMERA_CENTER;
			}
			else
			{
				cameraNum=field_passege.CAMERA_NUM.CAMERA_BACK;
			}
			break;
		}
		case "beltHitObjBack2":
		{
			if(cameraNum==field_passege.CAMERA_NUM.CAMERA_BACK2)
			{
				cameraNum=field_passege.CAMERA_NUM.CAMERA_BACK;
			}
			else
			{
				cameraNum=field_passege.CAMERA_NUM.CAMERA_BACK2;
			}
			break;
		}
		}
		GameObject.Find("CameraManager").GetComponent<field_passege>().ChangeCam(cameraNum);
		cameraBackUp = collider;
		
	}
}
