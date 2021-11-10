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
        if (score >= 1000)
        {
            PanelSet();
            resultPanels[0].SetActive(true);
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
