using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMaterialChanger : MonoBehaviour {

    public Material IncurruptMaterial;

	void Update ()
    {
        EnemyStatus enemyStatus = GetComponent<EnemyStatus>();
        
		if (!enemyStatus.isCurrupt)
        {
            GameObject enemyMesh = transform.Find("EnemyMesh").gameObject;

            Renderer renderer = enemyMesh.GetComponent<Renderer>();

            renderer.material  = IncurruptMaterial;

            Destroy(this);
        }
	}
}
