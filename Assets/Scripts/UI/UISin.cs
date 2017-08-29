using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UISin : MonoBehaviour {

	private UISin getUISin;

	public UISin GetSingle
    {
        get
        {
            if (getUISin == null)
            {
                getUISin = GameObject.Find("Canvas").GetComponent<UISin>();
            }

            return getUISin;
        }
	}
	private UISin(){}

	public Image[] heartimg;
    public Health Life;
    public GameObject ending;
    GameObject player;

    public bool end = false;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

	void Update()
    {    
        for (int i = 0; i < heartimg.Length; ++i)
        {
            if (i < Life.health)
            {
                heartimg[i].gameObject.SetActive(true);
            }
            else
            {
                heartimg[i].gameObject.SetActive(false);
            }

        }

        GameObject[] plants = GameObject.FindGameObjectsWithTag("Plant");

        if ((Life.health <= 0 || plants.Length == 0) && !end)
        {
            End();
        }
    }

    public int CalculateScore()
    {
        GameObject[] plants = GameObject.FindGameObjectsWithTag("Plant");

        int score = 0;

        foreach (GameObject plant in plants)
        {
            Plant plantScript = plant.GetComponent<Plant>();

            score += plantScript.plant_status;
        }

        return score;
    }

    void End()
    {
        ending.active = true;

        Score scoreScript = ending.transform.Find("Score").gameObject.GetComponent<Score>();

        scoreScript.score = CalculateScore();

        end = true;
    }

    public void OnBtn()
    {
        SceneManager.LoadSceneAsync("Reset");
    }
}
