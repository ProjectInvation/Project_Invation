using UnityEngine;
using System.Collections;
using System.Net;
using System;

public class NetworkMenu : MonoBehaviour 
{
	public GameObject prefab = null;
	
	
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
	
	private void OnConnectedToServer()
	{
		// A client has jast connected
		Network.Instantiate (prefab,  new Vector3 (0,5,0), Quaternion.identity, 0);
		connected = true;
	}
	
	private void OnServerInitialized()
	{
		// The server has initialzed
		Network.Instantiate (prefab, new Vector3 (0, 5, 0), Quaternion.identity, 0);
		connected = true;
	}
	
	
	private void OnDisconnectedFromServer()
	{
		// The connection has been lost, or disconnected
		connected = false;
	}
	
	private void OnGUI()
	{
		if (!connected) {
			connection_ip = GUILayout.TextField (connection_ip);
			int.TryParse (GUILayout.TextField (port_number.ToString ()), out port_number);
			
			if (GUILayout.Button ("Connect")) {
				Network.Connect (connection_ip, port_number);
			}
			if (GUILayout.Button ("Host")) {
				Network.InitializeServer (4, port_number, true);
			}
		} else {
			GUILayout.Label ("Connections: " + Network.connections.Length.ToString ());
			if (GUILayout.Button ("Disconnect")) {
				Network.Disconnect();
			}
		}
	}
}
