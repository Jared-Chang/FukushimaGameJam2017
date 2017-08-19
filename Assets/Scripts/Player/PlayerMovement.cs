using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    private float speed = 20;
    void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            gameObject.transform.position += new Vector3(0, 0, 1 * Time.fixedDeltaTime*speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.position += new Vector3(-1 * Time.fixedDeltaTime * speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.position += new Vector3(0, 0, -1 * Time.fixedDeltaTime * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.position += new Vector3(1 * Time.fixedDeltaTime * speed, 0, 0);
        }
    }
}
