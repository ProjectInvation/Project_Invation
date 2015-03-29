using UnityEngine;
using System.Collections;

public class thisBulletDestroy : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerEnter(Collider coll)
	{
		if(coll.tag=="Bullet")
		{
			GameObject.Find("GameManager").GetComponent<PointManager>().HandleScore(3);
			Destroy(this.gameObject);
		}
	}
}
