using UnityEngine;
using System.Collections;

public class Change : MonoBehaviour {
	
	int		count = 0;

	// Use this for initialization
	void Start () {
		count = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.C) || count > 30) {
			GetComponent<NetworkView> ().RPC ("SceneJump", RPCMode.All);
		}
		
		if(Network.connections.Length > 3)
			count++;
	}
	
	[RPC]
	public void SceneJump()
	{Application.LoadLevel ("ishida_test_2");}

}

