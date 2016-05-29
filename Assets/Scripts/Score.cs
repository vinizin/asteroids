using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score instance;

    public int currentScore = 0;
    public Text scoreText;
    public Text distanceText;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        UpdateDistance();
    }
    public void IncreaseScore()
    {
        currentScore++;
        scoreText.text = currentScore.ToString();
    }

    public void UpdateDistance()
    {
        int a = (int)Movement.instance.deltaDistance;
        distanceText.text = a.ToString() ;
    }




}
