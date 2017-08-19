using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
	public float time=3;//代表从A点出发到B经过的时长
	public GameObject PPoin;
	Transform pointA;//点A
	public Vector3 pointB;//点B
	public float g=10;//重力加速度
	// Use this for initialization
	private Vector3 speed;//初速度向量
	private Vector3 Gravity;//重力向量
	public enum ShitFly{
		Line,
		Sec

	}
	private bool ActSpeed=true;
	private float dTime=0;
	public ShitFly _shitfly;
	// Use this for initialization
	void Start () {
		pointA= this.transform;//将物体置于A点
		//通过一个式子计算初速度

	}
	
	// Update is called once per frame
	void Update () {
		if (pointB != Vector3.zero) {
			if (ActSpeed) {
				speed = new Vector3((pointB.x - pointA.position.x)/time,
					(pointB.y-pointA.position.y)/time-0.5f*g*time, (pointB.z - pointA.position.z) / time);
				Gravity = Vector3.zero;//重力初始速度为0
				ActSpeed = false;
			}
			switch (_shitfly) {
			case ShitFly.Line:
				transform.Translate (speed * Time.fixedDeltaTime);
				break;
			case ShitFly.Sec:

				Gravity.y = g * (dTime += Time.fixedDeltaTime);//v=at
			//模拟位移
				transform.Translate (speed * Time.fixedDeltaTime);
				transform.Translate (Gravity * Time.fixedDeltaTime);
				break;
			default:
				break;
			}
		}
		if (Vector3.Distance (transform.position, pointB) <= 1) {
			Destroy (this.gameObject);
		}
	}

}
