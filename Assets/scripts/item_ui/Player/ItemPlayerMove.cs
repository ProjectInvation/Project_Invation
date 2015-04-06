using UnityEngine;
using System.Collections;

public class ItemPlayerMove : MonoBehaviour
{
	public float MoveSpd;
	public string ThisName;

	private float angle;
	public float move_spd;
	public float rot_spd;

	// Use this for initialization
	void Start ()
	{
		angle=0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		//Move This Object
		Move();


		//Renderer Off
		//GetComponent<Renderer>().enabled = false;
	}

	void Move()
	{
		if(Input.GetKey(KeyCode.W))
		{
			this.transform.Translate(0,0,move_spd);
		}
		
		if(Input.GetKey(KeyCode.S))
		{
			this.transform.Translate(0,0,-move_spd);
		}
		
		if(Input.GetKey(KeyCode.A))
		{
			angle-=rot_spd;
			this.transform.rotation= Quaternion.Euler(0,angle,0);
		}
		
		if(Input.GetKey(KeyCode.D))
		{
			angle+=rot_spd;
			this.transform.rotation=Quaternion.Euler(0,angle,0);
		}
	}
}
