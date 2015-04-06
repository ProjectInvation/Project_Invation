using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour
{
	int thisItemID=0;
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	void OnCollisionEnter(Collision coll)
	{
		if(coll.collider.tag=="Player")
		{
			if(GameObject.Find("ItemManager").GetComponent<ItemManager>().AddItem(this.tag));
			{
				Destroy(this.gameObject);
			}
		}
	}
	
}
