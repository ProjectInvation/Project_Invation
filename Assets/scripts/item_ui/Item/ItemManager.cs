using UnityEngine;
using System.Collections;

public class ItemManager : MonoBehaviour
{
	const int ITEM_MAX=6;
	const int ITEM_ID_NONE=-1;
	const int ITEM_ID_ONE =0;

	private int[] HaveItemList= new int[ITEM_MAX]{ITEM_ID_NONE,ITEM_ID_NONE,ITEM_ID_NONE,ITEM_ID_NONE,ITEM_ID_NONE,ITEM_ID_NONE};
	private int HaveItem=0;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public bool AddItem(int ItemID)
	{
		if(HaveItem<=ITEM_MAX-1)
		{
			for(int i=0;i<ITEM_MAX;i++)
			{
				if(HaveItemList[i]==ITEM_ID_NONE)
				{
					HaveItemList[i]=ItemID;
					return true;
					break;
				}
			}
		}
		return false;
	}

	void OnGUI()
	{
		for(int i=0;i<ITEM_MAX;i++)
		{
			if(HaveItemList[i]!=ITEM_ID_NONE)
			{
				GUI.Label (new Rect (0,   i*30, 100, 30), "HAVE");
			}
			else
			{
				GUI.Label (new Rect (0,   i*30, 100, 30), "NONE");
			}
		}
	}
}
