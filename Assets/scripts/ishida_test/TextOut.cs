using UnityEngine;
using System.Collections;

public class TextOut : MonoBehaviour {

	private const int DISP_MODE_WAIT = 0;
	private const int DISP_MODE_HOST = 1;
	private const int DISP_MODE_CLIENT = 2;
	NetworkMenu net = new NetworkMenu ();
	private GUIStyleState style_state;
	private GUIStyle style;
	private string str_host;
	private string str_client;

	public static int now_disp_mode;
	public static int NowDispMode {
		get{ return now_disp_mode;}
		set
		{ now_disp_mode = value;}
	}

	// Use this for initialization
	void Start ()
	{
		// text initiate
		style = new GUIStyle();
		style.fontSize = 72;
		style_state = new GUIStyleState();
		style_state.textColor = Color.black;
		style.normal = style_state;
		now_disp_mode = DISP_MODE_HOST;
		str_host = " GameStart";
		str_client = "Host Wait GameScreen";
	}
	
	// Update is called once per frame
	void Update () {
		//if(now_disp_mode != net.DispMode())
		//	now_disp_mode = net.DispMode();
	}

	private void OnGUI()
	{
		switch(now_disp_mode)
		{
		case DISP_MODE_WAIT:
			break;
		case DISP_MODE_HOST:
			GUI.Label (new Rect (Screen.width/2-(style.fontSize*str_host.Length)/4,
			                     Screen.height/2-style.fontSize/2, style.fontSize*str_host.Length, style.fontSize), str_host,style);
			if (GUI.Button (new Rect (Screen.width/2,Screen.height/2+Screen.height/8, 172, 48), "Disconnect")) 
			{
				Network.Destroy(GameObject.Find("PlayerPrefab(Clone)").gameObject);
				Network.Disconnect();
			}
			break;
		case DISP_MODE_CLIENT:
			GUI.Label (new Rect (Screen.width/2-(style.fontSize*str_client.Length)/4,
			                     Screen.height/2-style.fontSize/2, style.fontSize*str_client.Length, style.fontSize), str_client,style);
			if (GUI.Button (new Rect (Screen.width/2,Screen.height/2+Screen.height/8, 172, 48), "Disconnect")) {
				Network.Destroy(GameObject.Find("PlayerPrefab(Clone)").gameObject);
				Network.Disconnect();
			}
			break;
		}
	}
}
