using UnityEngine;
using System.Collections;

public class Moves : MonoBehaviour 
{	
	// Update is called once per frame
	private void Update()
	{
		if (GetComponent<NetworkView> ().isMine)
		{
			if (Input.GetKey (KeyCode.UpArrow)) 
				GetComponent<NetworkView> ().RPC ("MoveUp", RPCMode.All, new object[] {1});
			if (Input.GetKey (KeyCode.DownArrow)) 
				GetComponent<NetworkView> ().RPC ("MoveDown", RPCMode.All, new object[] {1});
			if (Input.GetKey (KeyCode.LeftArrow)) 
				GetComponent<NetworkView> ().RPC ("MoveLeft", RPCMode.All, new object[] {1});
			if (Input.GetKey (KeyCode.RightArrow)) 
				GetComponent<NetworkView> ().RPC ("MoveRight", RPCMode.All, new object[] {1});
		}

	}
	
	[RPC]
	public void MoveUp(int dist)
	{transform.position += Vector3.forward * dist;}
	[RPC]
	public void MoveDown(int dist)
	{transform.position -= Vector3.forward * dist;}
	[RPC]
	public void MoveLeft(int dist)
	{transform.position += Vector3.left * dist;}
	[RPC]
	public void MoveRight(int dist)
	{transform.position -= Vector3.left * dist;}
}
