using UnityEngine;
using System.Collections;
using System.Net;
using System;

public class NetworkMenu : MonoBehaviour 
{
	public GameObject prefab;
	
	string connection_ip;
	public int port_number = 8632;
	
	private bool connected = false;
	
	private void Start ()
	{
		string host_name = Dns.GetHostName();
		IPAddress[] address = Dns.GetHostAddresses(host_name);
		foreach (IPAddress ip in address)
		{
			connection_ip = ip.ToString();
		}
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
		CreatePlayer ();
	}
	
	private void OnConnectedToServer()
	{
		// A client has jast connected
		Debug.Log ("Connected to server");
		connected = true;
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
		if (!connected) {
			connection_ip = GUILayout.TextField (connection_ip);
			int.TryParse (GUILayout.TextField (port_number.ToString ()), out port_number);
			
			if (GUILayout.Button ("Connect")) {
				Network.Connect (connection_ip, port_number);
				CreatePlayer ();
			}
			if (GUILayout.Button ("Host")) {
				Network.InitializeServer (4, port_number, true);
			}
		} else {
			GUILayout.Label ("Connections: " + Network.connections.Length.ToString ());
			if (GUILayout.Button ("Disconnect")) {
				Network.Destroy(GameObject.FindWithTag("Player"));
				Network.Disconnect();
			}
		}
	}
}