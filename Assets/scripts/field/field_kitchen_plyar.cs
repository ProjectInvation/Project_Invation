using UnityEngine;
using System.Collections;

public class field_kitchen_plyar : MonoBehaviour {

	GameObject playerObj;
	Collider cameraBackUp;
	
	field_kitchen.CAMERA_NUM cameraNum;
	
	// Use this for initialization
	void Start () {
		cameraBackUp = null;
		playerObj=GameObject.Find("Army3-final");
		cameraNum = field_kitchen.CAMERA_NUM.CAMERA_START;
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
		if (collider.tag != ("beltHitObjFront")) 
		{
			return;
		}
		
		switch (collider.tag) 
		{
			case "beltHitObjFront":
			{
				if(cameraNum==field_kitchen.CAMERA_NUM.CAMERA_START)
				{
					cameraNum=field_kitchen.CAMERA_NUM.CAMERA_END;
				}
				else
				{
					cameraNum=field_kitchen.CAMERA_NUM.CAMERA_START;
				}
				break;
			}
		}
		GameObject.Find("CameraManager").GetComponent<field_kitchen>().ChangeCam(cameraNum);
		cameraBackUp = collider;		
	}
}
