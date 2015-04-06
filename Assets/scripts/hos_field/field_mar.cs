using UnityEngine;
using System.Collections;

public class field_mar : MonoBehaviour {
	//busi
	GameObject busicameraObj1;
	GameObject busicameraObj2;
	GameObject busicameraObj3;
	GameObject busicameraObj4;
	GameObject busicameraObj5;

	//kit
	GameObject kitcameraObj1;
	GameObject kitcameraObj2;

	//pas
	GameObject pascameraObj1;
	GameObject pascameraObj2;
	GameObject pascameraObj3;
	GameObject pascameraObj4;
	GameObject pascameraObj5;
	GameObject pascameraObj6;
	GameObject pascameraObj7;

	//vip
	GameObject vipcameraObj1;
	GameObject vipcameraObj2;

	//ware
	GameObject warecameraObj1;
	GameObject warecameraObj2;
	GameObject warecameraObj3;
	GameObject warecameraObj4;

	public enum CAMERA_NUM
	{
		//busi
		BUSI_CAMERA_1=0,
		BUSI_CAMERA_2,
		BUSI_CAMERA_3,
		BUSI_CAMERA_4,
		BUSI_CAMERA_5,

		//kit
		KIT_CAMERA_1,
		KIT_CAMERA_2,
		//pas
		PAS_CAMERA_1,
		PAS_CAMERA_2,
		PAS_CAMERA_3,
		PAS_CAMERA_4,
		PAS_CAMERA_5,
		PAS_CAMERA_6,
		PAS_CAMERA_7,
		//vip
		VIP_CAMERA_1,
		VIP_CAMERA_2,
		//ware
		WARE_CAMERA_1,
		WARE_CAMERA_2,
		WARE_CAMERA_3,
		WARE_CAMERA_4,

		CAMERA_MAX
	};

	private CAMERA_NUM now_Camera;

	// Use this for initialization
	void Start () {

		busicameraObj1=GameObject.Find("Busi Camera 1");
		busicameraObj2=GameObject.Find("Busi Camera 2");
		busicameraObj3=GameObject.Find("Busi Camera 3");
		busicameraObj4=GameObject.Find("Busi Camera 4");
		busicameraObj5=GameObject.Find("Busi Camera 5");


		//kit
		kitcameraObj1=GameObject.Find("Kit Camera 1");
		kitcameraObj2=GameObject.Find("Kit Camera 2");

		//pas
		pascameraObj1=GameObject.Find("Pas Camera 1");
		pascameraObj2=GameObject.Find("Pas Camera 2");
		pascameraObj3=GameObject.Find("Pas Camera 3");
		pascameraObj4=GameObject.Find("Pas Camera 4");
		pascameraObj5=GameObject.Find("Pas Camera 5");
		pascameraObj6=GameObject.Find("Pas Camera 6");
		pascameraObj7=GameObject.Find("Pas Camera 7");

		//vip
		vipcameraObj1=GameObject.Find("Vip Camera 1");
		vipcameraObj2=GameObject.Find("Vip Camera 2");

		//ware
		warecameraObj1=GameObject.Find("Ware Camera 1");
		warecameraObj2=GameObject.Find("Ware Camera 2");
		warecameraObj3=GameObject.Find("Ware Camera 3");
		warecameraObj4=GameObject.Find("Ware Camera 4");

		busicameraObj1.SetActive (true);
		busicameraObj2.SetActive (false);
		busicameraObj3.SetActive (false);
		busicameraObj4.SetActive (false);
		busicameraObj5.SetActive (false);

		//kit
		kitcameraObj1.SetActive (false);
		kitcameraObj2.SetActive (false);
		
		//pas
		pascameraObj1.SetActive (false);
		pascameraObj2.SetActive (false);
		pascameraObj3.SetActive (false);
		pascameraObj4.SetActive (false);
		pascameraObj5.SetActive (false);
		pascameraObj6.SetActive (false);
		pascameraObj7.SetActive (false);

		//vip
		vipcameraObj1.SetActive (false);
		vipcameraObj2.SetActive (false);
		
		//ware
		warecameraObj1.SetActive (false);
		warecameraObj2.SetActive (false);
		warecameraObj3.SetActive (false);
		warecameraObj4.SetActive (false);

		now_Camera=CAMERA_NUM.BUSI_CAMERA_1;
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
		case CAMERA_NUM.BUSI_CAMERA_1:
			busicameraObj1.SetActive (false);
			break;
		case CAMERA_NUM.BUSI_CAMERA_2:
			busicameraObj2.SetActive (false);
			break;
		case CAMERA_NUM.BUSI_CAMERA_3:
			busicameraObj3.SetActive (false);
			break;
		case CAMERA_NUM.BUSI_CAMERA_4:
			busicameraObj4.SetActive (false);
			break;
		case CAMERA_NUM.BUSI_CAMERA_5:
			busicameraObj5.SetActive (false);
			break;

		case CAMERA_NUM.KIT_CAMERA_1:
			kitcameraObj1.SetActive (false);
			break;
		case CAMERA_NUM.KIT_CAMERA_2:
			kitcameraObj2.SetActive (false);
			break;

		case CAMERA_NUM.PAS_CAMERA_1:
			pascameraObj1.SetActive (false);
			break;
		case CAMERA_NUM.PAS_CAMERA_2:
			pascameraObj2.SetActive (false);
			break;
		case CAMERA_NUM.PAS_CAMERA_3:
			pascameraObj3.SetActive (false);
			break;
		case CAMERA_NUM.PAS_CAMERA_4:
			pascameraObj4.SetActive (false);
			break;
		case CAMERA_NUM.PAS_CAMERA_5:
			pascameraObj5.SetActive (false);
			break;
		case CAMERA_NUM.PAS_CAMERA_6:
			pascameraObj6.SetActive (false);
			break;
		case CAMERA_NUM.PAS_CAMERA_7:
			pascameraObj7.SetActive (false);
			break;

		case CAMERA_NUM.VIP_CAMERA_1:
			vipcameraObj1.SetActive (false);
			break;
		case CAMERA_NUM.VIP_CAMERA_2:
			vipcameraObj2.SetActive (false);
			break;

		case CAMERA_NUM.WARE_CAMERA_1:
			warecameraObj1.SetActive (false);
			break;
		case CAMERA_NUM.WARE_CAMERA_2:
			warecameraObj2.SetActive (false);
			break;
		case CAMERA_NUM.WARE_CAMERA_3:
			warecameraObj3.SetActive (false);
			break;
		case CAMERA_NUM.WARE_CAMERA_4:
			warecameraObj4.SetActive (false);
			break;
		}
		
		switch (Cam) 
		{
		case CAMERA_NUM.BUSI_CAMERA_1:
			busicameraObj1.SetActive (true);
			break;
		case CAMERA_NUM.BUSI_CAMERA_2:
			busicameraObj2.SetActive (true);
			break;
		case CAMERA_NUM.BUSI_CAMERA_3:
			busicameraObj3.SetActive (true);
			break;
		case CAMERA_NUM.BUSI_CAMERA_4:
			busicameraObj4.SetActive (true);
			break;
		case CAMERA_NUM.BUSI_CAMERA_5:
			busicameraObj5.SetActive (true);
			break;

		case CAMERA_NUM.KIT_CAMERA_1:
			kitcameraObj1.SetActive (true);
			break;
		case CAMERA_NUM.KIT_CAMERA_2:
			kitcameraObj2.SetActive (true);
			break;
			
		case CAMERA_NUM.PAS_CAMERA_1:
			pascameraObj1.SetActive (true);
			break;
		case CAMERA_NUM.PAS_CAMERA_2:
			pascameraObj2.SetActive (true);
			break;
		case CAMERA_NUM.PAS_CAMERA_3:
			pascameraObj3.SetActive (true);
			break;
		case CAMERA_NUM.PAS_CAMERA_4:
			pascameraObj4.SetActive (true);
			break;
		case CAMERA_NUM.PAS_CAMERA_5:
			pascameraObj5.SetActive (true);
			break;
		case CAMERA_NUM.PAS_CAMERA_6:
			pascameraObj6.SetActive (true);
			break;
		case CAMERA_NUM.PAS_CAMERA_7:
			pascameraObj7.SetActive (true);
			break;
			
		case CAMERA_NUM.VIP_CAMERA_1:
			vipcameraObj1.SetActive (true);
			break;
		case CAMERA_NUM.VIP_CAMERA_2:
			vipcameraObj2.SetActive (true);
			break;
			
		case CAMERA_NUM.WARE_CAMERA_1:
			warecameraObj1.SetActive (true);
			break;
		case CAMERA_NUM.WARE_CAMERA_2:
			warecameraObj2.SetActive (true);
			break;
		case CAMERA_NUM.WARE_CAMERA_3:
			warecameraObj3.SetActive (true);
			break;
		case CAMERA_NUM.WARE_CAMERA_4:
			warecameraObj4.SetActive (true);
			break;
		}
		
		now_Camera=Cam;
	}

}
