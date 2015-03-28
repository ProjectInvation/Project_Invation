using UnityEngine;
using System.Collections;

public class HandleBullet : MonoBehaviour 
{
	private float spd=2.1f;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		this.transform.Translate(0,0,spd);
	}

	void SetSpd(float f)
	{
		spd=f;
	}

	void OnTriggerEnter(Collider coll)
	{
		if(coll.tag!="Player")
		{
			Destroy(this.gameObject);
		}
	}
}
