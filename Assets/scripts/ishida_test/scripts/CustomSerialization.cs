using UnityEngine;
using System.Collections;

public class CustomSerialization : MonoBehaviour 
{
	private void Update()
	{
		if (Input.GetKeyDown (KeyCode.Space)) 
			GetComponent<NetworkView>().RPC ("JumpRight", RPCMode.All, new object[] {3});
	}

	[RPC]
	public void JumpRight(int dist)
	{
		transform.position += Vector3.right * dist;
	}
}
