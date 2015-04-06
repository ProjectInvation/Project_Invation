using UnityEngine;
using System.Collections;
using System.Net;
using System;

public class TextOut : MonoBehaviour {

	bool isPlayer;
	private const int DISP_MODE_WAIT = 0;
	private const int DISP_MODE_HOST = 1;
	private const int DISP_MODE_CLIENT = 2;

	NetworkMenu net = new NetworkMenu ();

	public static bool isChange;

	public static bool IsChange 
	{
		get {return isChange;}
		set {isChange = value;}
	}

	private GUIStyleState style_state;
	private GUIStyle style;
	private string str_host;
	private string str_client;

	public static int now_disp_mode;
	public static int NowDispMode {
		get{ return now_disp_mode;}
		set{ now_disp_mode = value;}
	}

	public static string connection_ip;
	public static string ConnectionIp {
		get{ return connection_ip;}
		set{ connection_ip = value;}
	}

	public static int port_number;
	public static int PortNumber {
		get{ return port_number;}
		set{ port_number = value;}
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
		isChange=false;
		isPlayer=false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(GameObject.Find("NetworkMenu").GetComponent<NetworkMenu>().PlayerID==1)
		{
			if(isPlayer)
			{
				if(!GameObject.Find("Player_1(Clone)"))
				{
					GameObject.Find("NetworkMenu").GetComponent<NetworkMenu>().PlayerID=0;
					Network.Disconnect();
					isChange=true;
				}
			}

			else
			{
				if(GameObject.Find("Player_2(Clone)"))
				{
					isPlayer=true;
				}
			}
		}
	}

	private void OnGUI()
	{
		GUILayout.Label ("" );
		switch(now_disp_mode)
		{
		case DISP_MODE_WAIT:
			break;
		case DISP_MODE_HOST:
			GUILayout.Label ("あなたはホストです");
			GUILayout.Label ("ip addreass :" + connection_ip.ToString());
			GUI.Label (new Rect (Screen.width/2-(style.fontSize*str_host.Length)/4,Screen.height/2-style.fontSize/2, style.fontSize*str_host.Length, style.fontSize), "接続者数: " + (Network.connections.Length+1).ToString(),style);
			if (GUI.Button (new Rect (Screen.width/2 + Screen.width/8,Screen.height/2+Screen.height/8, 172, 48), "切断する")) 
			{
				GetComponent<NetworkView> ().RPC ("Reset", RPCMode.All);
			}
			if (GUI.Button (new Rect (Screen.width/2 - Screen.width/4,Screen.height/2+Screen.height/8, 172, 48), "ゲーム開始")) 
			{
				GetComponent<NetworkView> ().RPC ("changeScene", RPCMode.All);
			}
			break;
		case DISP_MODE_CLIENT:
			GUILayout.Label ("あなたはクライアントです");
			GUILayout.Label ("Connections: " + Network.connections.Length.ToString ());
			GUI.Label (new Rect (Screen.width/2-(style.fontSize*str_client.Length)/4,Screen.height/2-style.fontSize/2, style.fontSize*str_client.Length, style.fontSize), str_client,style);
			if (GUI.Button (new Rect (Screen.width/2,Screen.height/2+Screen.height/8, 172, 48), "Disconnect"))
			{
				GetComponent<NetworkView> ().RPC ("Reset", RPCMode.All);
			}
			break;
		}
	}

	[RPC]
	void changeScene()
	{
		Application.LoadLevel("game_");
	}

	[RPC]
	void PlayerDelete()
	{
		for(int i=1;i<5;i++)
		{
			if(GameObject.Find("Player_"+i+"(Clone)"))
			{
				Network.Destroy(GameObject.Find("Player_"+i+"(Clone)"));
			}
		}
	}

	[RPC]
	void Reset()
	{
		for(int i=1;i<5;i++)
		{
			if(GameObject.Find("Player_"+i+"(Clone)"))
			{
				Network.Destroy(GameObject.Find("Player_"+i+"(Clone)"));
			}
		}

		Network.Disconnect();
		isChange=true;
		GameObject.Find("NetworkMenu").GetComponent<NetworkMenu>().PlayerID=0;
	}
}
