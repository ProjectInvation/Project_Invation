using UnityEngine;
using System.Collections;

public class BatScript : MonoBehaviour 
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
		GameObject.Find("UIManager").GetComponent<WeponUiManager>().ChangeWeponIcon("bat");
		GameObject.Find("UIManager").GetComponent<BulletUiManager>().SetBulletNone();
	}
	
	public void RemoveSet()
	{
		isUse=false;
	}
}
