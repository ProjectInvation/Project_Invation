using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayTextManager : MonoBehaviour 
{
	public Text DisplayText;

	// Use this for initialization
	void Start () 
	{
		DisplayText.text="";
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void SetDisplaytext(string text)
	{
		DisplayText.text=text;
	}
}
