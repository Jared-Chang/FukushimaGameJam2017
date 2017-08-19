using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant: MonoBehaviour
{

	public Material []  A;
	public Material []  B;
	public float Growtime;
	public float Witheredtime;
	public bool Grow_Withered;
	public GameObject Newplant;
	int plant_status;

	void Start ()
	{
		StartCoroutine("Grow");
	}

	void healling()
	{
		gameObject.GetComponent<Renderer>().material= A[plant_status];
		Grow_Withered=false;
		StartCoroutine("Grow");
	}

	void Wither()
	{
		StartCoroutine("Withered");
		Grow_Withered=true;
		gameObject.GetComponent<Renderer>().material= B[plant_status];
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag=="Bullet" || other.tag == "Enemy")
		{
			if(Grow_Withered==false)
			{
			    Wither();
			}
		}
		if(other.tag == "Heal" || other.tag == "Player")
		{
			if(Grow_Withered==true)
			{
			    healling();
			}
		}
		if(other.tag=="Player" && plant_status==A.Length-1 && Grow_Withered==false)
		{
			Instantiate(Newplant,new Vector3(transform.position.x+5,transform.position.y,transform.position.z), transform.rotation);
			plant_status=0;
			healling();
		}
	}

	IEnumerator Grow()
	{
		yield return new WaitForSeconds(Growtime);

		if(Grow_Withered==false && plant_status<A.Length-1)
		{
			plant_status++;
			gameObject.GetComponent<Renderer>().material= A[plant_status];
			StartCoroutine("Grow");
		}
	}

	IEnumerator Withered()
	{
		yield return new WaitForSeconds(Witheredtime);

		if(Grow_Withered==true && plant_status>0)
		{
			plant_status=plant_status-1;
			gameObject.GetComponent<Renderer>().material= B[plant_status];
			StartCoroutine("Withered");
		}
		else if(plant_status<=0)
		{
			Destroy(gameObject);
		}
	}
}
