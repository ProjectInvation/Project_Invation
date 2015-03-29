using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BulletUiManager : MonoBehaviour
{
	public int  LoadedBullets;
	public int CarryingBullets;

	// Use this for initialization
	void Start ()
	{
		//HandleLoadedBullet(0);
		SetBulletNone();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public bool HandleLoadedBullet(int UseBullet)
	{
		LoadedBullets+=UseBullet;

		if(LoadedBullets<=0)
		{
			LoadedBullets=0;
			GameObject.Find("inBullet").gameObject.GetComponent<Text>().text=""+LoadedBullets+"/"+CarryingBullets;
			return false;
		}

		if(LoadedBullets>=999)
		{
			LoadedBullets=999;
		}

		GameObject.Find("inBullet").gameObject.GetComponent<Text>().text=""+LoadedBullets+"/"+CarryingBullets;

		return true;
	}

	public bool HandleCarryingBullets(int UseBullet)
	{
		CarryingBullets+=UseBullet;
		
		if(CarryingBullets<=0)
		{
			CarryingBullets=0;
			GameObject.Find("inBullet").gameObject.GetComponent<Text>().text=""+LoadedBullets+"/"+CarryingBullets;
			return false;
		}
		
		if(CarryingBullets>=999)
		{
			CarryingBullets=999;
		}
		
		GameObject.Find("inBullet").gameObject.GetComponent<Text>().text=""+LoadedBullets+"/"+CarryingBullets;
		
		return true;
	}

	public void SetLoadedBullet(int bullet)
	{
		LoadedBullets=bullet;
		if(LoadedBullets<=0)
		{
			LoadedBullets=0;
		}
		
		if(LoadedBullets>=999)
		{
			LoadedBullets=999;
		}

		GameObject.Find("inBullet").gameObject.GetComponent<Text>().text=""+LoadedBullets+"/"+CarryingBullets;
		GameObject.Find("inBullet").gameObject.GetComponent<Text>().color=new Color32(0,0,0,255);
	}

	public void SetCarryingBullets(int bullet)
	{
		CarryingBullets=bullet;
		if(CarryingBullets<=0)
		{
			CarryingBullets=0;
		}
		
		if(CarryingBullets>=999)
		{
			CarryingBullets=999;
		}
		
		GameObject.Find("inBullet").gameObject.GetComponent<Text>().text=""+LoadedBullets+"/"+CarryingBullets;
		GameObject.Find("inBullet").gameObject.GetComponent<Text>().color=new Color32(0,0,0,255);
	}

	public void SetBulletNone()
	{
		LoadedBullets=0;
		CarryingBullets=0;

		GameObject.Find("inBullet").gameObject.GetComponent<Text>().text="";
	}

	public void SetBulletReload()
	{	
		GameObject.Find("inBullet").gameObject.GetComponent<Text>().text="Reloading";
		GameObject.Find("inBullet").gameObject.GetComponent<Text>().color=new Color32(255,0,0,255);
	}
}
