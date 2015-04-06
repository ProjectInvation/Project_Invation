using UnityEngine;
using System.Collections;

public class ChangeTitle : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.C)) {
			FadeManager.Instance.LoadLevel ("ishida_test",1f);
		}
	}
}
