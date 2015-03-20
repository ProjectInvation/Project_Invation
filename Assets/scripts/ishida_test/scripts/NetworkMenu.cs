using UnityEngine;
using System.Collections;

public class NetworkMenu : MonoBehaviour 
{
	public GameObject prefab = null;
	
	public string connection_ip	= "127.0.0.1";
	public int port_number = 8632;
	
	private bool connected = false;
	
	private void OnConnectedToServer()
	{
		// A client has jast connected
		connected = true;
		Network.Instantiate (prefab, new Vector3 (0,5,0), Quaternion.identity, 0);
	}
	
	private void OnServerInitialized()
	{
		// The server has initialzed
		connected = true;
		Network.Instantiate (prefab, new Vector3 (0,5,0), Quaternion.identity, 0);
	}
	
	
	private void OnDisconnectedFromServer()
	{
		// The connection has been lost, or disconnected
		connected = false;
	}
	
	private void OnGUI()
	{
		if (!connected)
		{
			connection_ip = GUILayout.TextField (connection_ip);
			int.TryParse(GUILayout.TextField (port_number.ToString()), out port_number);
			
			if (GUILayout.Button ("Connect"))
				Network.Connect (connection_ip, port_number);
			if (GUILayout.Button ("Host"))
				Network.InitializeServer (4, port_number, true);
		} else 
			GUILayout.Label ("Connections: " + Network.connections.Length.ToString());
	}
}
