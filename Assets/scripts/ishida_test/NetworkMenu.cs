using UnityEngine;
using System.Collections;
using System.Net;
using System;

public class NetworkMenu : MonoBehaviour 
{
	public GameObject prefab;

	public int now_disp_mode;

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
		now_disp_mode = DISP_MODE_WAIT;
		string host_name = Dns.GetHostName();
		IPAddress[] address = Dns.GetHostAddresses(host_name);
		foreach (IPAddress ip in address)
		{
			connection_ip = ip.ToString();
		}

		if (Network.isServer == true)
		{
			is_host = false;
		}
	}

	void Update()
	{
		// update disp mode
		TextOut.NowDispMode = now_disp_mode;
		TextOut.ConnectionIp = connection_ip;
		TextOut.PortNumber = port_number;
	}

	// player create
	private void CreatePlayer()
	{
		Network.Instantiate (prefab,  new Vector3 (Network.connections.Length * 2,5,0), Quaternion.identity, 0);
	}
	
	private void OnServerInitialized()
	{
		// The server has initialzed
		Debug.Log ("Server initialized and ready");
		connected = true;
		now_disp_mode = DISP_MODE_HOST;
		CreatePlayer ();
	}
	
	private void OnConnectedToServer()
	{
		// A client has jast connected
		Debug.Log ("Connected to server");
		connected = true;
		now_disp_mode = DISP_MODE_CLIENT;
		CreatePlayer ();
	}
	
	private void OnPlayerConnected(NetworkPlayer player)
	{
		Debug.Log ("Connected from" + player.ipAddress + ":" + player.port);
		connected = true;
	}
	
	
	private void OnPlayerDisconnected(NetworkPlayer player)
	{
		//
		Debug.Log ("Clean up after player" + player);
		Network.RemoveRPCs(player);
		Network.DestroyPlayerObjects (player);
	}
	
	private void OnDisconnectedFromServer(NetworkDisconnection info)
	{
		// The connection has been lost, or disconnected
		connected = false;
		now_disp_mode = DISP_MODE_WAIT;
		if (Network.isServer) 
		{Debug.Log ("Local server connection disconnected");}
		else if(info == NetworkDisconnection.LostConnection)
		{Debug.Log ("Lost connection to the server");}
		else
		{Debug.Log ("Successfully dicnnected from the server");}
	}
	
	private void OnFailedToConnect(NetworkConnectionError error)
	{
		if (Network.isServer) 
		{Debug.Log ("Could not connect to server:" + error);}
	}

	private void OnGUI()
	{
		switch(now_disp_mode)
		{
		case DISP_MODE_WAIT:
			if (!connected) 
			{
				GUILayout.Label ("Server: " + Network.isServer.ToString());
				GUILayout.Label ("Client: " + Network.isClient.ToString());
				connection_ip = GUILayout.TextField (connection_ip);
				int.TryParse (GUILayout.TextField (port_number.ToString ()), out port_number);

				if (GUILayout.Button ("Connect")) {
					Network.Connect (connection_ip, port_number);
					CreatePlayer ();
				}
				if(is_host == true)
				{
					if (GUILayout.Button ("Host"))
					{
						Network.InitializeServer (play_num, port_number, !Network.HavePublicAddress());
					}
				}
			}
			break;
		//case DISP_MODE_HOST:
			//GUILayout.Label ("Server: " + Network.isServer.ToString());
			//GUILayout.Label ("Client: " + Network.isClient.ToString());
			//GUILayout.Label ("Connections: " + Network.connections.Length.ToString ()+1);
			//GUILayout.Label ("Is Host");
			//GUILayout.Label ("ip addreass :" + connection_ip.ToString());
			//GUILayout.Label ("port :" + port_number.ToString());
			//if (GUILayout.Button ("Disconnect")) {
			//	Network.Destroy(GameObject.Find("PlayerPrefab(Clone)").gameObject);
			//	Network.Disconnect();
			//}
		//	break;
	//	case DISP_MODE_CLIENT:
			//GUILayout.Label ("Server: " + Network.isServer.ToString());
			//GUILayout.Label ("Client: " + Network.isClient.ToString());
			//GUILayout.Label ("Connections: " + Network.connections.Length.ToString ());
			//GUILayout.Label ("Is Client ");
			//if (GUILayout.Button ("Disconnect")) {
			//	Network.Destroy(GameObject.Find("PlayerPrefab(Clone)").gameObject);
			//	Network.Disconnect();
			//}
		//	break;
		}
	}
}

