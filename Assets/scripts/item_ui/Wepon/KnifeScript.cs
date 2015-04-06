using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class KnifeScript : MonoBehaviour
{
	private bool isUse=false;
	private bool canFire=false;
	private int coolDownCount;
	private int bulletSpd;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void ThisWeponSet()
	{
		isUse=true;
		GameObject.Find("GameManager").GetComponent<WeponUiManager>().ChangeWeponIcon("knife");
		GameObject.Find("GameManager").GetComponent<BulletUiManager>().SetBulletNone();
	}

	public void RemoveSet()
	{
		isUse=false;
	}
}
