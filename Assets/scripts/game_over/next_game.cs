﻿using UnityEngine;
using System.Collections;

public class next_game : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Return))
		{
			Application.LoadLevel("kitchen_field");
		}
	}
}
