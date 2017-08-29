using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public int score = 0;

    private void Update()
    {
        GameObject scoreText = transform.Find("Text").gameObject;
        Text text = scoreText.GetComponent<Text>();

        text.text = score.ToString();
    }
}
