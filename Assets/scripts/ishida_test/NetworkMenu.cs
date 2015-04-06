using UnityEngine;
using System.Collections;
using System.Net;
using System;

public class NetworkMenu : MonoBehaviour 
{
	public GameObject[] prefab= new GameObject[4];
	public int now_disp_mode;

	public int Now_disp_mode {
		get {
			return now_disp_mode;
		}
		set {
			now_disp_mode = value;
		}
	}

	public int playerID;

	public int PlayerID {
		get {
			return playerID;
		}
		set {
			playerID = value;
		}
	}

	private const int DISP_MODE_WAIT = 0;
	private const int DISP_MODE_HOST = 1;
	private const int DISP_MODE_CLIENT = 2;

	private bool is_host = true;
	

	public int play_num = 4;
	string connection_ip;
	public int port_number = 8632;
	
	private bool connected = false;
	
	private void Start ()
	{
		playerID=0;
		now_disp_mode = DISP_MODE_WAIT;
		string host_name = Dns.GetHostName();
		if(host_name!=null)
		{
			IPAddress[] address = Dns.GetHostAddresses(host_name);
			foreach (IPAddress ip in address)
			{
				connection_ip = ip.ToString();
			}
		}

		else
		{
			connection_ip="取得エラー:cmdからipアドレスを調べてください";
		}

		if (Network.isServer == true)
		{
			is_host = false;
		}
	}

	void Update()
	{
		if(TextOut.IsChange)
		{
			now_disp_mode=DISP_MODE_WAIT;
			TextOut.IsChange=false;
		}
		// update disp mode
		TextOut.NowDispMode = now_disp_mode;
		TextOut.ConnectionIp = connection_ip;
		TextOut.PortNumber = port_number;
	}

	// player create
	private void CreatePlayer()
	{
		for(int i=1;i<5;i++)
		{
			if(!GameObject.Find("Player_"+i+"(Clone)"))
			{
				playerID=i;
				Network.Instantiate (prefab[i-1],  new Vector3 (Network.connections.Length * 2,5,0), Quaternion.identity, 0);
				break;
			}
		}
	}
	
	private void OnServerInitialized()
	{
		connected = true;
		now_disp_mode = DISP_MODE_HOST;
		CreatePlayer();
	}
	
	private void OnConnectedToServer()
	{
		// A client has jast connected
		connected = true;
		now_disp_mode = DISP_MODE_CLIENT;
		StartCoroutine("createCliantPlayer");
	}
	
	private void OnPlayerConnected(NetworkPlayer player)
	{
		connected = true;
	}
	
	
	private void OnPlayerDisconnected(NetworkPlayer player)
	{
		Network.RemoveRPCs(player);
		Network.DestroyPlayerObjects (player);
	}
	
	private void OnDisconnectedFromServer(NetworkDisconnection info)
	{
		// The connection has been lost, or disconnected
		connected = false;
		now_disp_mode = DISP_MODE_WAIT;
	}
	
	private void OnFailedToConnect(NetworkConnectionError error)
	{
		if (Network.isServer) 
		{Debug.Log ("Could not connect to server:" + error);}
	}

	private void OnGUI()
	{
		GUILayout.Label ("あなたは "+playerID+"Pです" );
		switch(now_disp_mode)
		{
		case DISP_MODE_WAIT:
			if (!connected) 
			{
				//GUILayout.Label ("Server: " + Network.isServer.ToString());
				//GUILayout.Label ("Client: " + Network.isClient.ToString());
				connection_ip = GUILayout.TextField (connection_ip);
				int.TryParse (GUILayout.TextField (port_number.ToString ()), out port_number);

				if (GUILayout.Button ("ホストに接続")) {
					Network.Connect (connection_ip, port_number);
				}
				if(is_host == true)
				{
					if (GUILayout.Button ("ホストになる"))
					{
						Network.InitializeServer (play_num, port_number, !Network.HavePublicAddress());
					}
				}
			}
			break;
		}
	}

	IEnumerator createCliantPlayer()
	{
		yield return new WaitForSeconds(1);
		CreatePlayer();
	}
}

