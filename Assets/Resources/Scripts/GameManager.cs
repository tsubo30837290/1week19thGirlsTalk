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
    [SerializeField] Image spImage;

    public bool feverTime;

    void Start()
    {
        score = 0;
        scoreText.text = score.ToString();
        spImage.fillAmount = 0;
    }

    public void UpdateScoreUI()
    {
        score += ParamsSO.Entity.score;
        spImage.fillAmount += ParamsSO.Entity.sp;
        scoreText.text = score.ToString();
    }

    private void Update()
    {
        if (feverTime)
        {
            spImage.fillAmount -= 0.1f * Time.deltaTime;
        }
    }
}
