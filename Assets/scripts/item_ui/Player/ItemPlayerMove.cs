using UnityEngine;
using System.Collections;

public class ItemPlayerMove : MonoBehaviour
{
	public float MoveSpd;

	// Use this for initialization
	void Start ()
	{
	
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
			GameObject.Find("Player").transform.Translate(0,0,MoveSpd);
		}
		
		if(Input.GetKey(KeyCode.S))
		{
			GameObject.Find("Player").transform.Translate(0,0,-MoveSpd);
		}
		
		if(Input.GetKey(KeyCode.A))
		{
			GameObject.Find("Player").transform.Translate(-MoveSpd,0,0);
		}
		
		if(Input.GetKey(KeyCode.D))
		{
			GameObject.Find("Player").transform.Translate(MoveSpd,0,0);
		}
	}
}
