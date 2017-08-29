using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyMovement : MonoBehaviour
{
    Transform playerTransform;
    GameObject plant;
    UnityEngine.AI.NavMeshAgent nav;
    EnemyStatus enemyStatus;
	public EnemyMaterialChanger enemyMaterialChanger;
	public emydirection  emycha;
    double hangoutTimer = 500;
        
    void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        plant = FindNewTargetPlant();
        emydirection(plant);
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
				emydirection(plant);
            }
            else
            {
                plant = FindNewTargetPlant();

                emydirection(plant);
                Hangout();
            }
        }
		if(enemyMaterialChanger.wow==true)
		{
			emydirectionB(playerTransform);
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

            Vector3 hangoutPosition = new Vector3(Random.Range(-100, 100), 0, Random.Range(-100, 100));
			emydirectionA(hangoutPosition);
            nav.SetDestination(hangoutPosition);
        }
    }
	void emydirection(GameObject plant)
	{

		Vector3 angle = plant.transform.position - transform.position;
		//標準化
		angle = Vector3.Normalize(angle);

		if(angle.x>0.92 && angle.z<0.38 && angle.z > -0.38)
		{
			emycha.newact=emycha.emy_R1;
		}
		else if (angle.x < 0.92 && angle.x > 0.38 && angle.z > -0.92 && angle.z < -0.38)
		{
			emycha.newact=emycha.emy_F;
		}
		else if (angle.x > -0.38 && angle.x < 0.38 && angle.z < -0.92)
		{
			emycha.newact=emycha.emy_L1;
		}
		else if (angle.x < -0.38 && angle.x > -0.92 && angle.z > -0.92 && angle.z < -0.38)
		{
			emycha.newact=emycha.emy_L2;
		}
		else if (angle.x < -0.92 && angle.z < 0.38 && angle.z > -0.38)
		{
			emycha.newact=emycha.emy_L3;
		}
		else if (angle.x > -0.92 && angle.x < -0.38 && angle.z > 0.38 && angle.z < 0.92)
		{
			emycha.newact=emycha.emy_B;
		}
		else if (angle.x < 0.38 && angle.x > -0.38 && angle.z > 0.92)
		{
			emycha.newact=emycha.emy_R3;
		}
		else if (angle.x < 0.92 && angle.x > 0.38 && angle.z > 0.38 && angle.z < 0.92)
		{
			emycha.newact=emycha.emy_R2;
		}
		
	}
	void emydirectionA(Vector3 plant)
	{
		Vector3 angle = plant - transform.position;
		//標準化
		angle = Vector3.Normalize(angle);

		if(angle.x>0.92 && angle.z<0.38 && angle.z > -0.38)
		{
			emycha.newact=emycha.emy_R1;
		}
		else if (angle.x < 0.92 && angle.x > 0.38 && angle.z > -0.92 && angle.z < -0.38)
		{
			emycha.newact=emycha.emy_F;
		}
		else if (angle.x > -0.38 && angle.x < 0.38 && angle.z < -0.92)
		{
			emycha.newact=emycha.emy_L1;
		}
		else if (angle.x < -0.38 && angle.x > -0.92 && angle.z > -0.92 && angle.z < -0.38)
		{
			emycha.newact=emycha.emy_L2;
		}
		else if (angle.x < -0.92 && angle.z < 0.38 && angle.z > -0.38)
		{
			emycha.newact=emycha.emy_L3;
		}
		else if (angle.x > -0.92 && angle.x < -0.38 && angle.z > 0.38 && angle.z < 0.92)
		{
			emycha.newact=emycha.emy_B;
		}
		else if (angle.x < 0.38 && angle.x > -0.38 && angle.z > 0.92)
		{
			emycha.newact=emycha.emy_R3;
		}
		else if (angle.x < 0.92 && angle.x > 0.38 && angle.z > 0.38 && angle.z < 0.92)
		{
			emycha.newact=emycha.emy_R2;
		}
	}
	void emydirectionB(Transform ww)
	{
		Vector3 angle = ww.position - transform.position;
		//標準化
		angle = Vector3.Normalize(angle);
		
		if(angle.x>0.92 && angle.z<0.38 && angle.z > -0.38)
		{
			emycha.newact=emycha.emy2_R1;
		}
		else if (angle.x < 0.92 && angle.x > 0.38 && angle.z > -0.92 && angle.z < -0.38)
		{
			emycha.newact=emycha.emy2_F;
		}
		else if (angle.x > -0.38 && angle.x < 0.38 && angle.z < -0.92)
		{
			emycha.newact=emycha.emy2_L1;
		}
		else if (angle.x < -0.38 && angle.x > -0.92 && angle.z > -0.92 && angle.z < -0.38)
		{
			emycha.newact=emycha.emy2_L2;
		}
		else if (angle.x < -0.92 && angle.z < 0.38 && angle.z > -0.38)
		{
			emycha.newact=emycha.emy2_L3;
		}
		else if (angle.x > -0.92 && angle.x < -0.38 && angle.z > 0.38 && angle.z < 0.92)
		{
			emycha.newact=emycha.emy2_B;
		}
		else if (angle.x < 0.38 && angle.x > -0.38 && angle.z > 0.92)
		{
			emycha.newact=emycha.emy2_R3;
		}
		else if (angle.x < 0.92 && angle.x > 0.38 && angle.z > 0.38 && angle.z < 0.92)
		{
			emycha.newact=emycha.emy2_R2;
		}
	}
}