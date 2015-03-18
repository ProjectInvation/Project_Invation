using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.W))
		{
			transform.Translate(0.0f,0.0f,0.1f) ;
		}
		if(Input.GetKey(KeyCode.S))
		{
			transform.Translate(0.0f,0.0f,-0.1f) ;
		}
		if(Input.GetKey(KeyCode.A))
		{
			transform.Rotate(0.0f,-1.0f,0.0f) ;
		}
		if(Input.GetKey(KeyCode.D))
		{
			transform.Rotate(0.0f,1.0f,0.0f) ;
		}

	}
}
