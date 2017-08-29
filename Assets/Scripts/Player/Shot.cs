using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public float flyspeed = 5;
    public float disapearDistance = 10;

	Transform pointA;
	public Vector3 pointB;

	private Vector3 speed;

    private Vector3 beginPoint;

	private bool ActSpeed=true;
    
    void Awake()
    {
        beginPoint = this.transform.position;
    }

	void Start ()
    {
		pointA= this.transform;
	}
	
	void Update ()
    {
		if (ActSpeed)
        {
            speed = new Vector3(pointB.x - pointA.position.x, 0, pointB.z - pointA.position.z).normalized * flyspeed;
			ActSpeed = false;
		}
		transform.Translate (speed * Time.fixedDeltaTime);
        
		if (Vector3.Distance (beginPoint, transform.position) >= disapearDistance)
        {
            Destroy(this.gameObject);
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Plant")
        {
            Destroy(this.gameObject);
        }
    }

}
