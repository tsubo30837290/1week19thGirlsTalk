using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result : MonoBehaviour
{
    [SerializeField] GameObject[] resultPanels;

    int score;

    void Start()
    {
        score = GameManager.instance.score;

        // スコアごとの振り分け
        if (score >= 15000)
        {
            SoundManager.instance.PlayBGM("HighScoreClear");
            PanelSet();
            resultPanels[0].SetActive(true);
        }
        else if (score < 15000 && score >= 13500)
        {
            SoundManager.instance.PlayBGM("NormalClear");
            PanelSet();
            resultPanels[1].SetActive(true);
        }
        else if (score < 13500 && score >= 12000)
        {
            SoundManager.instance.PlayBGM("NormalClear");
            PanelSet();
            resultPanels[2].SetActive(true);
        }
        else if (score < 12000 && score >= 10000)
        {
            SoundManager.instance.PlayBGM("NormalClear");
            PanelSet();
            resultPanels[3].SetActive(true);
        }
        else if (score < 10000)
        {
            SoundManager.instance.PlayBGM("NormalClear");
            PanelSet();
            resultPanels[4].SetActive(true);
        }
    }

    void PanelSet()
    {
        for (int i = 0; i < resultPanels.Length; i++)
        {
            resultPanels[i].SetActive(false);
        }
    }
}
