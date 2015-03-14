using UnityEngine;
using System.Collections;

public class EnemyCharacter : MonoBehaviour {
	private GameObject Player;

	// Use this for initialization
	void Start () {
		Player = GameObject.Find ("PlayerObject");
	}
	
	// Update is called once per frame
	void Update () {
		//Axis get
		Vector3 Axis = Player.transform.position - this.transform.position;

		//Move if it's the close distance
		if (Axis.magnitude <= 10) {
			Axis.y = 0;
			Axis.Normalize();

			this.transform.forward = Axis;
			this.transform.position += Axis / 50;
		}
	}
}
