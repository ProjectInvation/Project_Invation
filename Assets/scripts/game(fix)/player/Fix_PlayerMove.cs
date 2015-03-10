using UnityEngine;
using System.Collections;

public class Fix_PlayerMove : MonoBehaviour 
{
	//Player Movement Spd
	public float move_spd=0.0001f;
	private GameObject Player;

	// Use this for initialization
	void Start ()
	{
		Player=GameObject.Find("Army 01");
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetKey(KeyCode.W))
		{
			Player.transform.Translate(0,0,move_spd);
		}

		if(Input.GetKey(KeyCode.S))
		{
			Player.transform.Translate(0,0,-move_spd);
		}

		if(Input.GetKey(KeyCode.A))
		{
			Player.transform.Translate(-move_spd,0,0);
		}

		if(Input.GetKey(KeyCode.D))
		{
			Player.transform.Translate(move_spd,0,0);
		}

	}
}
