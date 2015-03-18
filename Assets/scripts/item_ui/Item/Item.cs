using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour
{
	public string thisItemID="item_none";
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
			if(GameObject.Find("ItemManager").GetComponent<ItemManager>().AddItem(thisItemID))
			{
				Destroy(this.gameObject);
			}
		}
	}
	
}
