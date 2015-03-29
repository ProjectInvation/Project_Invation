using UnityEngine;
using System.Collections;

public class HandleBullet : MonoBehaviour 
{
	public float Movespd=2.1f;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		this.transform.Translate(0,0,Movespd);
	}

	void SetSpd(float f)
	{
		Movespd=f;
	}

	void OnTriggerEnter(Collider coll)
	{
		if(coll.tag!="Player")
		{
			Destroy(this.gameObject);
		}
	}
}
