using UnityEngine;
using System.Collections;

public class field_mar_player : MonoBehaviour {

	GameObject playerObj;
	Collider cameraBackUp;

	field_mar.CAMERA_NUM cameraNum;

	// Use this for initialization
	void Start ()
	{
		cameraBackUp = null;
		playerObj=GameObject.Find("Army-Final");
		cameraNum = field_mar.CAMERA_NUM.BUSI_CAMERA_1;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKey(KeyCode.W))
		{
			playerObj.transform.Translate(0,0,0.3f);
		}	
		if(Input.GetKey(KeyCode.S))
		{
			playerObj.transform.Translate(0,0,-0.3f);
		}
		if(Input.GetKey(KeyCode.A))
		{
			playerObj.transform.Rotate(0,-5.0f,0);
		}
		if(Input.GetKey(KeyCode.D))
		{
			playerObj.transform.Rotate(0,5.0f,0);
		}

	}

	void OnTriggerExit(Collider collider)
	{
		if(this.name=="Player_"+GameObject.Find("NetworkMenu").GetComponent<NetworkMenu>().PlayerID+"(Clone)")
		{
			if (collider.tag != ("busi_belt_hit_1") && 
			    collider.tag != ("busi_belt_hit_2") && 
			    collider.tag != ("busi_belt_hit_3") && 
			    collider.tag != ("busi_belt_hit_4") && 
			    collider.tag != ("busi_belt_hit_5") && 
			    collider.tag != ("ware_belt_hit_1") && 
			    collider.tag != ("ware_belt_hit_2") && 
			    collider.tag != ("ware_belt_hit_3") && 
			    collider.tag != ("ware_belt_hit_4") && 
			    collider.tag != ("vip_belt_hit_1") && 
			    collider.tag != ("vip_belt_hit_2") && 
			    collider.tag != ("pas_belt_hit_1") && 
			    collider.tag != ("pas_belt_hit_2") && 
			    collider.tag != ("pas_belt_hit_3") && 
			    collider.tag != ("pas_belt_hit_4") && 
			    collider.tag != ("pas_belt_hit_5") && 
			    collider.tag != ("pas_belt_hit_6") && 
			    collider.tag != ("kit_belt_hit_1") && 
			    collider.tag != ("kit_belt_hit_2"))
			{
				return;
			}
			
			switch (collider.tag) 
			{
			case "busi_belt_hit_2":
				{
					if(cameraNum==field_mar.CAMERA_NUM.BUSI_CAMERA_1)
					{
						cameraNum=field_mar.CAMERA_NUM.BUSI_CAMERA_2;
					}
					else
					{
						cameraNum=field_mar.CAMERA_NUM.BUSI_CAMERA_1;
					}
					break;
				}
			case "busi_belt_hit_3":
			{
				if(cameraNum==field_mar.CAMERA_NUM.BUSI_CAMERA_2)
				{
					cameraNum=field_mar.CAMERA_NUM.BUSI_CAMERA_3;
				}
				else
				{
					cameraNum=field_mar.CAMERA_NUM.BUSI_CAMERA_2;
				}
				break;
			}
			
			case "busi_belt_hit_4":
			{
				if(cameraNum==field_mar.CAMERA_NUM.BUSI_CAMERA_3)
				{
					cameraNum=field_mar.CAMERA_NUM.BUSI_CAMERA_4;
				}
				else
				{
					cameraNum=field_mar.CAMERA_NUM.BUSI_CAMERA_3;
				}
				break;
			}
			
			case "busi_belt_hit_5":
			{
				if(cameraNum==field_mar.CAMERA_NUM.BUSI_CAMERA_4)
				{
					cameraNum=field_mar.CAMERA_NUM.BUSI_CAMERA_5;
				}
				else
				{
					cameraNum=field_mar.CAMERA_NUM.BUSI_CAMERA_4;
				}
				break;
			}
			
			case "pas_belt_hit_1":
			{
				if(cameraNum==field_mar.CAMERA_NUM.PAS_CAMERA_6)
				{
					cameraNum=field_mar.CAMERA_NUM.PAS_CAMERA_7;
				}
				else
				{
					cameraNum=field_mar.CAMERA_NUM.PAS_CAMERA_6;
				}
				break;
			}


			case "pas_belt_hit_2":
			{
				if(cameraNum==field_mar.CAMERA_NUM.PAS_CAMERA_3)
				{
					cameraNum=field_mar.CAMERA_NUM.PAS_CAMERA_6;
				}
				else
				{
					cameraNum=field_mar.CAMERA_NUM.PAS_CAMERA_3;
				}
				break;
			}
			
			case "pas_belt_hit_3":
			{
				if(cameraNum==field_mar.CAMERA_NUM.BUSI_CAMERA_1)
				{
					cameraNum=field_mar.CAMERA_NUM.PAS_CAMERA_1;
				}
				else
				{
					cameraNum=field_mar.CAMERA_NUM.BUSI_CAMERA_1;
				}
				break;
			}

			case "pas_belt_hit_4":
			{
				if(cameraNum==field_mar.CAMERA_NUM.PAS_CAMERA_1)
				{
					cameraNum=field_mar.CAMERA_NUM.PAS_CAMERA_2;
				}
				else
				{
					cameraNum=field_mar.CAMERA_NUM.PAS_CAMERA_1;
				}
				break;
			}

			case "pas_belt_hit_5":
			{
				if(cameraNum==field_mar.CAMERA_NUM.PAS_CAMERA_3)
				{
					cameraNum=field_mar.CAMERA_NUM.PAS_CAMERA_5;
				}
				else
				{
					cameraNum=field_mar.CAMERA_NUM.PAS_CAMERA_3;
				}
				break;
			}

			case "pas_belt_hit_6":
			{
				if(cameraNum==field_mar.CAMERA_NUM.PAS_CAMERA_2)
				{
					cameraNum=field_mar.CAMERA_NUM.PAS_CAMERA_3;
				}
				else
				{
					cameraNum=field_mar.CAMERA_NUM.PAS_CAMERA_2;
				}
				break;
			}

			case "kit_belt_hit_1":
			{
				if(cameraNum==field_mar.CAMERA_NUM.PAS_CAMERA_7)
				{
					cameraNum=field_mar.CAMERA_NUM.KIT_CAMERA_2;
				}
				else
				{
					cameraNum=field_mar.CAMERA_NUM.PAS_CAMERA_7;
				}
				break;
			}

			case "kit_belt_hit_2":
			{
				if(cameraNum==field_mar.CAMERA_NUM.KIT_CAMERA_2)
				{
					cameraNum=field_mar.CAMERA_NUM.KIT_CAMERA_1;
				}
				else
				{
					cameraNum=field_mar.CAMERA_NUM.KIT_CAMERA_2;
				}
				break;
			}

			case "vip_belt_hit_2":
			{
				if(cameraNum==field_mar.CAMERA_NUM.PAS_CAMERA_5)
				{
					cameraNum=field_mar.CAMERA_NUM.VIP_CAMERA_1;
				}
				else
				{
					cameraNum=field_mar.CAMERA_NUM.PAS_CAMERA_5;
				}
				break;
			}

			case "vip_belt_hit_1":
			{
				if(cameraNum==field_mar.CAMERA_NUM.VIP_CAMERA_1)
				{
					cameraNum=field_mar.CAMERA_NUM.VIP_CAMERA_2;
				}
				else
				{
					cameraNum=field_mar.CAMERA_NUM.VIP_CAMERA_1;
				}
				break;
			}

			case "ware_belt_hit_1":
			{
				if(cameraNum==field_mar.CAMERA_NUM.VIP_CAMERA_2)
				{
					cameraNum=field_mar.CAMERA_NUM.WARE_CAMERA_4;
				}
				else
				{
					cameraNum=field_mar.CAMERA_NUM.VIP_CAMERA_2;
				}
				break;
			}
			
			case "ware_belt_hit_2":
			{
				if(cameraNum==field_mar.CAMERA_NUM.WARE_CAMERA_4)
				{
					cameraNum=field_mar.CAMERA_NUM.WARE_CAMERA_3;
				}
				else
				{
					cameraNum=field_mar.CAMERA_NUM.WARE_CAMERA_4;
				}
				break;
			}
			
			case "ware_belt_hit_3":
			{
				if(cameraNum==field_mar.CAMERA_NUM.WARE_CAMERA_3)
				{
					cameraNum=field_mar.CAMERA_NUM.WARE_CAMERA_2;
				}
				else
				{
					cameraNum=field_mar.CAMERA_NUM.WARE_CAMERA_3;
				}
				break;
			}
			
			case "ware_belt_hit_4":
			{
				if(cameraNum==field_mar.CAMERA_NUM.WARE_CAMERA_2)
				{
					cameraNum=field_mar.CAMERA_NUM.WARE_CAMERA_1;
				}
				else
				{
					cameraNum=field_mar.CAMERA_NUM.WARE_CAMERA_2;
				}
				break;
			}


			}

			GameObject.Find("Camera Manager").GetComponent<field_mar>().ChangeCam(cameraNum);
			cameraBackUp = collider;
		}
	}
}
