using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BornMonst : MonoBehaviour {


	public Object Monst;
	public float BornSec;
	private float ResTime;
	// Use this for initialization
	void Start () {
		ResTime = BornSec;
	}
	
	// Update is called once per frame
	void Update () {
		if (Monst != null) {
			BornSec -= Time.deltaTime;
			if (BornSec <= 0) {
				BornSec = ResTime;
				Instantiate(Monst,new Vector3(Random.Range(transform.position.x-transform.localScale.x*0.5f,transform.position.x+transform.localScale.x*0.5f),0,Random.Range(transform.position.z-transform.localScale.z*0.5f,transform.position.z+transform.localScale.z*0.5f)),Quaternion.identity);
			}
		}
	}
}
