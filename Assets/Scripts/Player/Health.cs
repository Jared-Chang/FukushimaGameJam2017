using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health=4;

    bool isColliding = false;

    void OnTriggerEnter(Collider other) 
    {
        if (isColliding) { return; }

        if (other.gameObject.tag == "Enemy") 
        {
            isColliding = true;
            health--;
        }
    }

    void Update()
    {
        isColliding = false;
    }
}
