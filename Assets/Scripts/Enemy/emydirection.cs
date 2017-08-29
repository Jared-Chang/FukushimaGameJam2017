using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emydirection : MonoBehaviour {
	public Texture[] emy_B;
	public Texture[] emy_F;
	public Texture[] emy_L1;
	public Texture[] emy_L2;
	public Texture[] emy_L3;
	public Texture[] emy_R1;
	public Texture[] emy_R2;
	public Texture[] emy_R3;

	public Texture[] newact;


	public Texture[] emy2_B;
	public Texture[] emy2_F;
	public Texture[] emy2_L1;
	public Texture[] emy2_L2;
	public Texture[] emy2_L3;
	public Texture[] emy2_R1;
	public Texture[] emy2_R2;
	public Texture[] emy2_R3;

	// Use this for initialization
	void Start () {
		StartCoroutine("Cha");
		newact= emy_F;
	}
	
	// Update is called once per frame
	void Update () {

	}
	IEnumerator Cha()
	{
		for(int i = 0;i<emy_B.Length;i++)
		{
			yield return new WaitForSeconds(0.03f);
			gameObject.GetComponent<Renderer>().material.mainTexture= newact[i];
		}
		StartCoroutine("Cha");
	}
}
