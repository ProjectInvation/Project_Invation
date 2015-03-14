using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {
	public GameObject object_prefab;
	string ip 	= "127.0.0.1";
	string port = "20000";
	bool connected = false;

	private void CreatePlayer()
	{
		connected = true;
		Network.Instantiate (object_prefab, object_prefab.transform.position,
		                    object_prefab.transform.rotation, 1);
	}

	public void OnConnectToServer()
	{connected = true;}

	public void OnServerInitialized()
	{CreatePlayer();}

	public void OnGUI()
	{
		if (GUI.Button (new Rect (10, 10, 90, 90), "Client")) {
			Network.Connect(ip,int.Parse(port));
		}
		if (GUI.Button (new Rect (10, 110, 90, 90), "Master")) {
			Network.InitializeServer(10,int.Parse(port),false);
		}
	}

	void AnyMetho(string name, int num)
	{
		// RPC keiyudejixtukousitaimesoxtudo
	}


}
