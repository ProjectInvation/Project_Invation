using UnityEngine;
using System.Collections;

public class title_manager : MonoBehaviour 
{
	//Use GameObject
	private GameObject tps;
	private GameObject tps_back;
	private GameObject fix;
	private GameObject fix_back;

	//start select fix
	private bool is_fix = true;

	// Use this for initialization
	void Start ()
	{
		tps = GameObject.Find ("Tps Logo");
		tps_back = GameObject.Find ("Tps Back Logo");
		fix = GameObject.Find ("Fix Logo");
		fix_back = GameObject.Find ("Fix Back Logo");
	}
	
	// Update is called once per frame
	void Update ()
	{
		//If KeyDown Select Next Scene
		if(Input.GetKeyDown(KeyCode.UpArrow)||Input.GetKeyDown(KeyCode.DownArrow))
		{
			//Other One Select
			is_fix=!is_fix;
		}

		//Switch Active 
		if (is_fix)
		{
			//Fix Select
			fix.SetActive(false);
			fix_back.SetActive(true);
			tps.SetActive(true);
			tps_back.SetActive(false);
		}

		else
		{
			//TPS Select
			fix.SetActive(true);
			fix_back.SetActive(false);
			tps.SetActive(false);
			tps_back.SetActive(true);
		}

		//
		if(Input.GetKeyDown(KeyCode.Return))
		{
			//
			if(is_fix)
			{
				//Scene Change Fix
				Application.LoadLevel("fix");
			}else
			{
				//Scene Change Tps
				Application.LoadLevel("tps");
			}

		}
	}

}
