using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GugeManager : MonoBehaviour
{
	public RectTransform HelthTrans;
	private float cachedY;
	private float minValue;
	private float maxValue;
	private float currentHealth;
	public float maxHealth;
	public Image visualHelth;

	// Use this for initialization
	void Start ()
	{
		cachedY=HelthTrans.position.y;
		maxValue=HelthTrans.position.x;
		minValue=-HelthTrans.position.x;
		currentHealth=maxHealth;

	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetKey(KeyCode.Return))
		{
			currentHealth-=1;
		}
		
		else if(Input.GetKey(KeyCode.Space))
		{
			currentHealth+=1;
		}

		if(currentHealth<0)
		{
			currentHealth=0;
		}

		if(currentHealth>maxHealth)
		{
			currentHealth=maxHealth;
		}

		HandleHelthbar(currentHealth,maxHealth);
	}

	public void HandleHelthbar(float current,float max)
	{
		float CullentValues=MapValues(current,0,max,minValue,maxValue);
		HelthTrans.position=new Vector3(CullentValues,cachedY,0);

		if(current>max/2)
		{
			visualHelth.color=new Color32((byte)MapValues(current,max/2,max,255,0),255,0,255);
		}

		else
		{
			visualHelth.color=new Color32(255,(byte)MapValues(current,0,max/2,0,255),0,255);
		}
	}

	private float MapValues(float x,float inMin,float inMax,float outMin,float outMax)
	{
		return ((x-inMin)*(outMax-outMin)/(inMax-inMin)+outMin);
	}
}
