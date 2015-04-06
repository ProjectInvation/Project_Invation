using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WeponManager : MonoBehaviour
{
	private const int WeponKnife  =0;
	private const int WeponBat    =1;
	private const int WeponHandGun=2;
	private const int WeponRifle  =3;

	private int[] haveWeponList= new int[2]{WeponHandGun,WeponRifle};
	private int CurrentWepon=100;

	// Use this for initialization
	void Start()
	{
		SetCurrentWepon(haveWeponList[0]);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetKeyDown(KeyCode.UpArrow))
		{
			SetCurrentWepon(haveWeponList[0]);
		}
		
		if(Input.GetKeyDown(KeyCode.DownArrow))
		{
			SetCurrentWepon(haveWeponList[1]);
		}
	}

	private void SetCurrentWepon(int wepon)
	{
		switch (CurrentWepon)
		{
		case WeponKnife:
			GameObject.Find("WeponManager").GetComponent<KnifeScript>().RemoveSet();
			break;
		case WeponBat:
			GameObject.Find("WeponManager").GetComponent<BatScript>().RemoveSet();
			break;
		case WeponHandGun:
			GameObject.Find("WeponManager").GetComponent<HandgunScript>().RemoveSet();
			break;
		case WeponRifle:
			GameObject.Find("WeponManager").GetComponent<RifleScript>().RemoveSet();
			break;
		}

		switch (wepon)
		{
		case WeponKnife:
			GameObject.Find("WeponManager").GetComponent<KnifeScript>().ThisWeponSet();
			break;
		case WeponBat:
			GameObject.Find("WeponManager").GetComponent<BatScript>().ThisWeponSet();
			break;
		case WeponHandGun:
			GameObject.Find("WeponManager").GetComponent<HandgunScript>().ThisWeponSet();
			break;
		case WeponRifle:
			GameObject.Find("WeponManager").GetComponent<RifleScript>().ThisWeponSet();
			break;
		}

		CurrentWepon=wepon;
	}
}
