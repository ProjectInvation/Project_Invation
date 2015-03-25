using UnityEngine;
using System.Collections;

public class EnemyCharacter : MonoBehaviour {
	public int ObjNum;						//Player Object Num

	private Vector3 Axis;					//Player to Enemy Distance And Axis
	private GameObject [] Players;

	private float MoveSpeed = 0.01f;

	// Use this for initialization
	void Start () {
		Players = new GameObject[ObjNum];

	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < ObjNum; i++) {
			Players[i] = GameObject.Find("PlayerObject_" + (i+1));
		}
		int count = 0;
		//GetAxis
		for (int i = 0; i < this.ObjNum; i++) {
			if (Players [i] == null)
			{
				count++;
				continue;
			}
			if(i == count)
			{
				Axis = Players[i].transform.position - this.transform.position;
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
			this.transform.Translate(0,0,MoveSpeed);
		}
	}
}
