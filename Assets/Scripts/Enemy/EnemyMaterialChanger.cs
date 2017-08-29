using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMaterialChanger : MonoBehaviour {

    public Material IncurruptMaterial;
	public bool wow = false;
	void Update ()
    {
        EnemyStatus enemyStatus = GetComponent<EnemyStatus>();
        
		if (!enemyStatus.isCurrupt &&  wow == false)
        {
            GameObject enemyMesh = transform.Find("EnemyMesh").gameObject;
			wow = true;
			Renderer renderer = enemyMesh.GetComponent<Renderer>();

            renderer.material  = IncurruptMaterial;
        }
	}
}
