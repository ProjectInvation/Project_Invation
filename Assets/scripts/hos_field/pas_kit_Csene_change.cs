using UnityEngine;
using System.Collections;

public class pas_kit_Csene_change : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider coll)
	{
		if(coll.tag==("Pas Scene kitchen Belt"))
		{
			switch(coll.tag)
			{
			case "Pas Scene kitchen Belt":
				Application.LoadLevel("kitchen_field");
				break;
			}
		}
	}
}
