using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // Awake : Startより前に呼ばれる関数
    private void Awake()
    {
        instance = this;
    }

    // Scoreを表示する
    [SerializeField] Text scoreText;
    int score;

    void Start()
    {
        score = 0;
        scoreText.text = score.ToString();
    }

    public void UpdateScoreUI()
    {
        score += ParamsSO.Entity.score;
        scoreText.text = score.ToString();
    }
}
