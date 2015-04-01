using UnityEngine;
using System.Collections;

public class ChangeScene2 : MonoBehaviour {
	
	int		count = 0;
	bool	delete_object = false;
	//public char scene = null;
	// Use this for initialization
	void Start () {
		count = 0;
		delete_object = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (count > 30) {
			//GetComponent<NetworkView> ().RPC ("PlayerDelete", RPCMode.All);
			GetComponent<NetworkView> ().RPC ("SceneJump", RPCMode.All);
		}
		
		if ((Input.GetKeyDown (KeyCode.C)) && (delete_object == false)) {
			GetComponent<NetworkView> ().RPC ("PlayerDelete", RPCMode.All);
			GetComponent<NetworkView> ().RPC ("FlagChange", RPCMode.All);
		}
		
		if(delete_object)
			count++;
	}
	
	private void OnDestroy()
	{
		Network.Disconnect();
		GameObject.DestroyObject(GameObject.FindWithTag("NetworkObject"));
	}
	
	[RPC]
	public void SceneJump()
	{Application.LoadLevel ("network");}
	
	
	[RPC]
	public void PlayerDelete()
	{Network.Destroy(GameObject.FindWithTag("Player"));}
	
	[RPC]
	public void FlagChange()
	{
		if (delete_object != true)
			delete_object = true;
		else
			delete_object = false;
	}
}

