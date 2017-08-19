using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Plant")
        {
            EnemyStatus enemyStatus = GetComponent<EnemyStatus>();

            enemyStatus.isCurrupt = false;
        }
        else if (other.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
