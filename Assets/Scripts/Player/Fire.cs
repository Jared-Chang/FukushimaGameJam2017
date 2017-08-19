using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{

    private int attackType= 0 ;
    public GameObject bullet;
	
	void Update ()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bul =  Instantiate(bullet, transform.position, transform.rotation);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            Physics.Raycast(ray, out hit);

            bul.GetComponent<Shot>().pointB =new Vector3( hit.point.x,1.6f, hit.point.z);
        }
	}
}
