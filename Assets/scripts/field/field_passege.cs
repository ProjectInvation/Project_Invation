using UnityEngine;
using System.Collections;

public class field_passege : MonoBehaviour {

	GameObject cameraObjStart;
	GameObject cameraObjFront;
	GameObject cameraObjCenter;
	GameObject cameraObjCenterLeft;
	GameObject cameraObjCenterRight;
	GameObject cameraObjBack;
	GameObject cameraObjBack2;
	
	public enum CAMERA_NUM
	{
		CAMERA_START=0,
		CAMERA_FRONT,
		CAMERA_CENTER,
		CAMERA_CENTER_LEFT,
		CAMERA_CENTER_RIGHT,
		CAMERA_BACK,
		CAMERA_BACK2,
		CAMERA_MAX
	};
	private CAMERA_NUM now_Camera;
	
	// Use this for initialization
	void Start () {
		cameraObjStart=GameObject.Find("Pas Interim Camera");
		cameraObjFront=GameObject.Find("Pas This Side Camera");
		cameraObjCenter=GameObject.Find("Pas Center Camera");
		cameraObjCenterLeft=GameObject.Find("Pas Back Int Camera");
		cameraObjCenterRight=GameObject.Find("Pas Back Camera");
		cameraObjBack=GameObject.Find("Pas Right Int Camera");
		cameraObjBack2=GameObject.Find("Pas Right Camera");

		cameraObjStart.SetActive(true);
		cameraObjFront.SetActive(false);
		cameraObjCenter.SetActive(false);
		cameraObjCenterLeft.SetActive(false);
		cameraObjCenterRight.SetActive(false);
		cameraObjBack.SetActive(false);
		cameraObjBack2.SetActive(false);

		now_Camera=CAMERA_NUM.CAMERA_START;
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void ChangeCam(CAMERA_NUM Cam)
	{
		if (now_Camera == Cam) {
			return;
		}
		
		switch (now_Camera) 
		{
		case CAMERA_NUM.CAMERA_START:
			cameraObjStart.SetActive (false);
			break;
			
		case CAMERA_NUM.CAMERA_FRONT:
			cameraObjFront.SetActive (false);
			break;
			
		case CAMERA_NUM.CAMERA_CENTER:
			cameraObjCenter.SetActive (false);
			break;
			
		case CAMERA_NUM.CAMERA_CENTER_LEFT:
			cameraObjCenterLeft.SetActive (false);
			break;
			
		case CAMERA_NUM.CAMERA_CENTER_RIGHT:
			cameraObjCenterRight.SetActive (false);
			break;
			
		case CAMERA_NUM.CAMERA_BACK:
			cameraObjBack.SetActive (false);
			break;

		case CAMERA_NUM.CAMERA_BACK2:
			cameraObjBack2.SetActive (false);
			break;
		}
		
		switch (Cam) 
		{
		case CAMERA_NUM.CAMERA_START:
			cameraObjStart.SetActive (true);
			break;
			
		case CAMERA_NUM.CAMERA_FRONT:
			cameraObjFront.SetActive (true);
			break;
			
		case CAMERA_NUM.CAMERA_CENTER:
			cameraObjCenter.SetActive (true);
			break;
			
		case CAMERA_NUM.CAMERA_CENTER_LEFT:
			cameraObjCenterLeft.SetActive (true);
			break;
			
		case CAMERA_NUM.CAMERA_CENTER_RIGHT:
			cameraObjCenterRight.SetActive (true);
			break;
			
		case CAMERA_NUM.CAMERA_BACK:
			cameraObjBack.SetActive (true);
			break;

		case CAMERA_NUM.CAMERA_BACK2:
			cameraObjBack2.SetActive (true);
			break;
		}
		
		now_Camera=Cam;
	}
}
