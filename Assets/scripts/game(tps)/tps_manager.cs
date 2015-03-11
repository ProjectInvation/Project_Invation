using UnityEngine;
using System.Collections;

public class tps_manager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetKeyDown(KeyCode.Return))
		{
			//Scene Change Fix
			Application.LoadLevel("title");
		}	
	}
}
