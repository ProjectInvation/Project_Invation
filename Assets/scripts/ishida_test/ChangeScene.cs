using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {
	
	private int		count;
	private bool	delete_object;
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
			GetComponent<NetworkView> ().RPC ("FlagTrue", RPCMode.All);
		}
		
		if(delete_object)
			count++;
	}
	
	private void OnDestroy()
	{
		Network.Disconnect();
		GameObject.DestroyObject(GameObject.Find("NetworkMenu").gameObject);
	}
	
	[RPC]
	public void SceneJump()
	{Application.LoadLevel ("ishida_test");}

	
	[RPC]
	public void PlayerDelete()
	{Network.Destroy(GameObject.Find("PlayerPrefab(Clone)").gameObject);}
	
	[RPC]
	public void FlagTrue()
	{delete_object = true;}

}

