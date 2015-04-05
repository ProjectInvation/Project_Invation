using UnityEngine;
using System.Collections;

public class ResponManager : MonoBehaviour
{
	public Transform[] PlayerRespon;
	public GameObject[] PlayerObject;
	public int playerID;

	public int PlayerID {
		get {
			return playerID;
		}
		set {
			playerID = value;
		}
	}

	// Use this for initialization
	void Start ()
	{
		StartCoroutine("ResponPlayer");
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	
	IEnumerator ResponPlayer()
	{
		yield return new WaitForSeconds(1);
		playerID=GameObject.Find("NetworkMenu").GetComponent<NetworkMenu>().PlayerID;
		Network.Instantiate (PlayerObject[playerID-1],  PlayerRespon[playerID-1].position, Quaternion.identity, 0);
	}
}
