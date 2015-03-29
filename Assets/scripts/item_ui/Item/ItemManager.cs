using UnityEngine;
using System.Collections;

public class ItemManager : MonoBehaviour
{
	const int ITEM_MAX=6;
	const string ITEM_ID_NONE="item_none";

	private string[] HaveItemList= new string[ITEM_MAX]{ITEM_ID_NONE,ITEM_ID_NONE,ITEM_ID_NONE,ITEM_ID_NONE,ITEM_ID_NONE,ITEM_ID_NONE};
	private int HaveItem=0;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public bool AddItem(string ItemID)
	{
		if(HaveItem<=ITEM_MAX-1)
		{
			for(int i=0;i<ITEM_MAX;i++)
			{
				if(HaveItemList[i]==ITEM_ID_NONE)
				{
					HaveItemList[i]=ItemID;
					return true;
				}
			}
		}
		return false;
	}

	void OnGUI()
	{
	//	for(int i=0;i<ITEM_MAX;i++)
	//	{
	//		GUI.Label (new Rect (0,   i*30, 100, 30), HaveItemList[i]);
	//	}
	}
}
