using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerController : MonoBehaviour
{
    public Text timerTexts;
    // カウントダウン時間
    float totalTime; 
    int retime;

    void Start()
    {
        totalTime = ParamsSO.Entity.timeLimit;
    }

    void Update()
    {
        if (!GameManager.instance.isFinish)
        {
            totalTime -= Time.deltaTime;
            retime = (int)totalTime;
            int m = retime / 60; // 60で割った商:分
            int s = retime % 60; // 60で割ったあまり：秒
            timerTexts.text = string.Format("{0:D2}:{1:D2}", m, s);

            //タイマーが0になったらシーン移動
            if (retime <= 0)
            {
                timerTexts.text = "00:00";
                GameManager.instance.isFinish = true;
                // ｼｰﾝ移動
                //SceneManager.LoadScene("");

                GameManager.instance.GameFinish();
            }
        }
    }
}
