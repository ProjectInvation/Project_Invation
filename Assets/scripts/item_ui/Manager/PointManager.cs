using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PointManager : MonoBehaviour
{
	public int Score;

	// Use this for initialization
	void Start ()
	{
		GameObject.Find("Point").gameObject.GetComponent<Text>().text=""+Score;
	}
	
	// Update is called once per frame
	void Update ()
	{

	}
	
	public void HandleScore(int score)
	{
		//Add Score
		Score+=score;

		//Min
		if(Score<=0)
		{
			Score=0;
		}

		//Max
		else if(Score>=999999999)
		{
			Score=999999999;
		}

		//Change Score in UI
		GameObject.Find("Point").gameObject.GetComponent<Text>().text=""+Score;
	}

	public void SetScore(int score)
	{
		//Set Score
		Score=score;
		
		//Min
		if(Score<=0)
		{
			Score=0;
		}
		
		//Max
		else if(Score>=999999999)
		{
			Score=999999999;
		}
		
		//Change Score in UI
		GameObject.Find("Point").gameObject.GetComponent<Text>().text=""+Score;
	}

	public int GetScore()
	{
		return (Score);
	}
}
