using UnityEngine;
using System.Collections;

public class field_kitchen : MonoBehaviour {

	GameObject cameraObjStart;
	GameObject cameraObjEnd;
	
	public enum CAMERA_NUM
	{
		CAMERA_START=0,
		CAMERA_END,
		CAMERA_MAX
	};
	private CAMERA_NUM now_Camera;
	
	// Use this for initialization
	void Start () {
		cameraObjStart=GameObject.Find("Kitchen End Camera");
		cameraObjEnd=GameObject.Find("Kitchen Start Camera");
		
		cameraObjStart.SetActive(true);
		cameraObjEnd.SetActive(false);


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
			
		case CAMERA_NUM.CAMERA_END:
			cameraObjEnd.SetActive (false);
			break;
		}
		
		switch (Cam) 
		{
		case CAMERA_NUM.CAMERA_START:
			cameraObjStart.SetActive (true);
			break;
			
		case CAMERA_NUM.CAMERA_END:
			cameraObjEnd.SetActive (true);
			break;
		}
		
		now_Camera=Cam;
	}
}
