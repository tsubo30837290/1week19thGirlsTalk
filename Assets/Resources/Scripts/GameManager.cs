using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] GameObject[] player;

    [SerializeField] GameObject finishImage;

    // Awake : Startより前に呼ばれる関数
    private void Awake()
    {
        instance = this;
    }

    // Scoreを表示する
    [SerializeField] Text scoreText;
    public int score;
    [SerializeField] Image spImage;

    public bool feverTime;

    public bool isFinish;

    void Start()
    {
        PlayerInstance();
        score = 0;
        scoreText.text = score.ToString();
        spImage.fillAmount = 0;
    }

    public void UpdateScoreUI()
    {
        if (!isFinish)
        {
            if (!feverTime)
            {
                score += ParamsSO.Entity.score;
                spImage.fillAmount += ParamsSO.Entity.sp;
                scoreText.text = score.ToString();
            }
            else
            {
                score += ParamsSO.Entity.feverScore;
                spImage.fillAmount += ParamsSO.Entity.sp;
                scoreText.text = score.ToString();
            }
        }
    }

    private void Update()
    {
        if (!isFinish)
        {
            if (feverTime)
            {
                spImage.fillAmount -= 0.1f * Time.deltaTime;
            }
            else
            {
                spImage.fillAmount += 0.01f * Time.deltaTime;
            }

            if (spImage.fillAmount >= 1)
            {
                FeverTime();
            }
            else if (spImage.fillAmount <= 0)
            {
                FeverTime();
            }
        }
    }

    void PlayerInstance()
    {
        int n = Random.Range(0, player.Length);
        Instantiate(player[n], new Vector3(0, -4, 0), transform.rotation);
    }

    void FeverTime()
    {
        if (feverTime)
        {
            feverTime = false;
            SoundManager.instance.PlayBGM("Main");
        }
        else
        {
            feverTime = true;
            SoundManager.instance.PlayBGM("Fever");
        }
    }

    public void GameFinish()
    {
        StartCoroutine(finishMove());
    }

    IEnumerator finishMove()
    {
        // 終了SE
        finishImage.SetActive(true);

        yield return new WaitForSeconds(2);

        SceneMove.instance.MainToClear();
    }
}
