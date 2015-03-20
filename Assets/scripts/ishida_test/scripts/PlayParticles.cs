using UnityEngine;
using System.Collections;

public class PlayParticles : MonoBehaviour {
	private void Update () 
	{
		if (GetComponent<NetworkView> ().isMine)
		{
			if (Input.GetKeyDown (KeyCode.Space)) 
				GetComponent<NetworkView> ().RPC ("DoExploder", RPCMode.All, new object[] {15});
			else if (Input.GetKeyDown (KeyCode.Return)) 
				GetComponent<NetworkView> ().RPC ("DoExploder", RPCMode.All, new object[] {1500});
		}
		else
		{
			if (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown (KeyCode.Return))
				Debug.Log("Client is not allowed to particle madness");
		}
	}

	[RPC]
	public void DoExploder(int count)
	{
		GetComponent<ParticleSystem>().Emit (count);
	}
}
