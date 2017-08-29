using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Fire : MonoBehaviour
{

    private int attackType= 0 ;
    public GameObject bullet1;
    public GameObject bullet2;
    RaycastHit hit;
	public  PlayerDirection cha;

    void Update ()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ChangeDirection();
            GameObject bul =  Instantiate(bullet1, transform.position, transform.rotation);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            Physics.Raycast(ray, out hit);

            bul.GetComponent<Shot>().pointB =new Vector3( hit.point.x,1.6f, hit.point.z);
            
        }
        if (Input.GetButtonDown("Fire2"))
        {
            ChangeDirection();
            GameObject bul = Instantiate(bullet2, transform.position, transform.rotation);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            Physics.Raycast(ray, out hit);

            bul.GetComponent<Shot>().pointB = new Vector3(hit.point.x, 1.6f, hit.point.z);
        }
    }

    private void ChangeDirection()
    {
        Vector3 angle = hit.point - transform.position;
        angle = Vector3.Normalize(angle);

        if (angle.x > 0.92 && angle.z < 0.38 && angle.z > -0.38)
        {
            cha.newact = cha.ROBOT_R1;
        }
        else if (angle.x < 0.92 && angle.x > 0.38 && angle.z > -0.92 && angle.z < -0.38)
        {
            cha.newact = cha.ROBOT_F;
        }
        else if (angle.x > -0.38 && angle.x < 0.38 && angle.z < -0.92)
        {
            cha.newact = cha.ROBOT_L1;
        }
        else if (angle.x < -0.38 && angle.x > -0.92 && angle.z > -0.92 && angle.z < -0.38)
        {
            cha.newact = cha.ROBOT_L2;

        }
        else if (angle.x < -0.92 && angle.z < 0.38 && angle.z > -0.38)
        {
            cha.newact = cha.ROBOT_L3;
        }
        else if (angle.x > -0.92 && angle.x < -0.38 && angle.z > 0.38 && angle.z < 0.92)
        {
            cha.newact = cha.ROBOT_B;
        }
        else if (angle.x < 0.38 && angle.x > -0.38 && angle.z > 0.92)
        {
            cha.newact = cha.ROBOT_R3;
        }
        else if (angle.x < 0.92 && angle.x > 0.38 && angle.z > 0.38 && angle.z < 0.92)
        {
            cha.newact = cha.ROBOT_R2;
        }
    }
}
