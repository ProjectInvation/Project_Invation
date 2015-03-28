using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HandgunScript : MonoBehaviour
{
	private bool canFire=false;
	
	private bool isUse=false;
	
	private float coolDownCount=0.5f;
	private float coolDownReload=1.5f;
	private int bulletSpd;
	
	private int LoadedMax=6;
	private int CarryingMax=36;

	private int LoadedBullet=6;
	private int CarryingBullet=36;

	
	public GameObject prefab;
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.F)&&isUse&&canFire)
		{
			Fire();
		}
		
		if(Input.GetKeyDown(KeyCode.G)&&isUse&&canFire)
		{
			StartCoroutine("coolDownAndReload");
		}
		
		
	}
	
	public void ThisWeponSet()
	{
		isUse=true;
		canFire=true;
		GameObject.Find("GameManager").GetComponent<WeponUiManager>().ChangeWeponIcon("handgun");
		GameObject.Find("GameManager").GetComponent<BulletUiManager>().SetCarryingBullets(CarryingBullet);
		GameObject.Find("GameManager").GetComponent<BulletUiManager>().SetLoadedBullet(LoadedBullet);
	}
	
	public void RemoveSet()
	{
		isUse=false;
		canFire=false;
	}
	
	IEnumerator coolDownAndReload()
	{
		if(LoadedBullet!=LoadedMax&&CarryingBullet>0)
		{
			canFire=false;
			GameObject.Find("GameManager").GetComponent<BulletUiManager>().SetBulletReload();
			yield return new WaitForSeconds(coolDownReload);
			Reload();
			GameObject.Find("GameManager").GetComponent<BulletUiManager>().SetCarryingBullets(CarryingBullet);
			GameObject.Find("GameManager").GetComponent<BulletUiManager>().SetLoadedBullet(LoadedBullet);
			canFire=true;
		}
	}
	
	IEnumerator coolDownFire()
	{
		canFire=false;
		yield return new WaitForSeconds(coolDownCount);
		canFire=true;
	}
	
	void Fire()
	{
		if(LoadedBullet>0)
		{
			LoadedBullet-=1;
			Instantiate (prefab, GameObject.Find("BulletStart").transform.position, GameObject.Find("BulletStart").transform.rotation);
			GameObject.Find("GameManager").GetComponent<BulletUiManager>().SetLoadedBullet(LoadedBullet);
			StartCoroutine("coolDownFire");
		}
	}
	
	void Reload()
	{
		if(LoadedBullet<LoadedMax)
		{
			int ReloadBulletNum=LoadedMax-LoadedBullet;
			
			if(CarryingBullet>=ReloadBulletNum)
			{
				CarryingBullet-=ReloadBulletNum;
				LoadedBullet+=ReloadBulletNum;
			}
			
			else
			{
				LoadedBullet+=CarryingBullet;
				CarryingBullet=0;
			}
		}
		
		GameObject.Find("GameManager").GetComponent<BulletUiManager>().SetCarryingBullets(CarryingBullet);
		GameObject.Find("GameManager").GetComponent<BulletUiManager>().SetLoadedBullet(LoadedBullet);
		
	}
}
