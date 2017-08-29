using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDirection : MonoBehaviour {
	public Texture[] ROBOT_B;
	public Texture[] ROBOT_F;
	public Texture[] ROBOT_L1;
	public Texture[] ROBOT_L2;
	public Texture[] ROBOT_L3;
	public Texture[] ROBOT_R1;
	public Texture[] ROBOT_R2;
	public Texture[] ROBOT_R3;
	public Texture[] newact;
	// Use this for initialization
	void Start () {
		StartCoroutine("Cha");
		newact= ROBOT_B;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	IEnumerator Cha()
	{
		for(int i = 0;i<ROBOT_B.Length;i++)
		{
			yield return new WaitForSeconds(0.03f);
			gameObject.GetComponent<Renderer>().material.mainTexture= newact[i];
		}
		StartCoroutine("Cha");
	}
}
