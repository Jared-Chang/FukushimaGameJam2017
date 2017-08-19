using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyMovement : MonoBehaviour
{
    Transform playerTransform;
    GameObject plant;
    UnityEngine.AI.NavMeshAgent nav;
    EnemyStatus enemyStatus;

    double hangoutTimer = 500;
        
    void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        plant = FindNewTargetPlant();
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        enemyStatus = GetComponent<EnemyStatus>();
    }

    void Update()
    {
        if (!enemyStatus.isCurrupt)
        {
            nav.SetDestination(playerTransform.position);
        }
        else
        {
            if (plant != null)
            {
                nav.SetDestination(plant.transform.position);

                plant = UpdatePlantStatus();
            }
            else
            {
                plant = FindNewTargetPlant();
                Hangout();
            }
        }
    }

    GameObject UpdatePlantStatus()
    {
        Plant plantScript = plant.GetComponent<Plant>();

        if (!plantScript.Grow_Withered)
        {
            return plant;
        }
        else
        {
            return null;
        }
    }

    GameObject FindNewTargetPlant()
    {
        GameObject[] plants;
        List<GameObject> notCurruptPlants = new List<GameObject>();

        plants = GameObject.FindGameObjectsWithTag("Plant");
        
        foreach (GameObject plant in plants)
        {
            Plant plantScript = plant.GetComponent<Plant>();

            if (!plantScript.Grow_Withered)
            {
                notCurruptPlants.Add(plant);
            }
        }

        int plantIndex = Random.Range(0, notCurruptPlants.Count - 1);

        return notCurruptPlants.Count != 0 ? notCurruptPlants[plantIndex] : null;
    }

    void Hangout()
    {
        hangoutTimer += Time.deltaTime;

        if (hangoutTimer > 2)
        {
            hangoutTimer = 0;

            Vector3 hangoutPosition = new Vector3(Random.Range(-30, 30), 0, Random.Range(-30, 30));

            nav.SetDestination(hangoutPosition);
        }
    }
}