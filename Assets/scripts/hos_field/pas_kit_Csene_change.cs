﻿using UnityEngine;
using System.Collections;

public class pas_kit_csene_change : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider coll)
	{
		if(coll.tag==("Player"))
		{
				Application.LoadLevel("kitchen_field");
		}

	}
}
