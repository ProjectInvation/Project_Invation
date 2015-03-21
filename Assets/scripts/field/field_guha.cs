using UnityEngine;
using System.Collections;

public class field_guha : MonoBehaviour {

	GameObject cameraObjStart;
	GameObject cameraObjFront;
	GameObject cameraObjCenter;
	GameObject cameraObjCenterLeft;
	GameObject cameraObjCenterRight;
	GameObject cameraObjBack;

	public enum CAMERA_NUM
	{
		CAMERA_START=0,
		CAMERA_FRONT,
		CAMERA_CENTER,
		CAMERA_CENTER_LEFT,
		CAMERA_CENTER_RIGHT,
		CAMERA_BACK,
		CAMERA_MAX
	};
	private CAMERA_NUM now_Camera;

	// Use this for initialization
	void Start () {
		cameraObjStart=GameObject.Find("Busi Start Camera");
		cameraObjFront=GameObject.Find("Busi Front Camera");
		cameraObjCenter=GameObject.Find("Busi Center Camera");
		cameraObjCenterLeft=GameObject.Find("Busi Center Left Camera");
		cameraObjCenterRight=GameObject.Find("Busi Center Right Camera");
		cameraObjBack=GameObject.Find("Busi Back Camera");

		cameraObjStart.SetActive(true);
		cameraObjFront.SetActive(false);
		cameraObjCenter.SetActive(false);
		cameraObjCenterLeft.SetActive(false);
		cameraObjCenterRight.SetActive(false);
		cameraObjBack.SetActive(false);

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
		}

		now_Camera=Cam;
	}

}
