using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    private int health=100;

    void OnCollisionEnter(Collision aaa) 
    {
        if (aaa.gameObject.name == "Enemy") 
        {
            Debug.Log("123");
            health -= 10;
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
