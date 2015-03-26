using UnityEngine;
using System.Collections;

public class EnemyCharacter : MonoBehaviour {
	public int ObjNum;						//Player Object Num

	private Vector3 Axis;					//Player to Enemy Distance And Axis
	private GameObject [] Players;

	// Use this for initialization
	void Start () {
		Players = new GameObject[ObjNum];
		for (int i = 0; i < ObjNum; i++) {
			Players[i] = GameObject.Find("PlayerObject_" + (i+1));
		}
	}
	
	// Update is called once per frame
	void Update () {
		//GetAxis
		for (int i = 0; i < this.ObjNum; i++) {
			if(i == 0)
			{
				Axis = Players[0].transform.position - this.transform.position;
			}else{
				Vector3 CurAxis = Players[i].transform.position - this.transform.position;
				if(CurAxis.sqrMagnitude < this.Axis.sqrMagnitude)
				{
					Axis = CurAxis;
				}
			}
		}
		Axis.y = 0;
		//Move if it's the close distance
		if (Axis.magnitude <= 10) {
			Axis.y = 0;
			Axis.Normalize();

			this.transform.forward = Axis;
			this.transform.position += Axis / 50;
		}
	}
}
