using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WeponUiManager : MonoBehaviour
{
	public Sprite knife;
	public Sprite bat;
	public Sprite handgun;
	public Sprite riful;

	public Image icon;

	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	public void ChangeWeponIcon(string name)
	{
		switch (name)
		{
		case "knife":
			icon.sprite=knife;
			break;
		case "bat":
			icon.sprite=bat;
			break;
		case "handgun":
			icon.sprite=handgun;
			break;
		case "rifle":
			icon.sprite=riful;
			break;
		}
	}
}
