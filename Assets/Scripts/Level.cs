using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    public static Level instance;

    public Text levelText;
    public float currentLevel = 0;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {

    }
    public void IncreaseLevel()
    {
        currentLevel++;
        levelText.text = string.Format("Level: {0}", currentLevel);
    }
}
