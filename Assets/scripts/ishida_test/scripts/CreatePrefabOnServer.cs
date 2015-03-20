using UnityEngine;
using System.Collections;

public class CreatePrefabOnServer : MonoBehaviour {
	public GameObject prefab = null;

	// Update is called once per frame
	private void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Space))
			Network.Instantiate (prefab, Vector3.zero, Quaternion.identity, 0);
	}
}
