using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public enum SCENE
    {
        Title,
        Main,
        Clear,
    }
    public SCENE scene = SCENE.Title;

    void Start()
    {
        if (scene == SCENE.Title)
        {
            MusicStart("Title");
        }
        else if (scene == SCENE.Main)
        {
            MusicStart("Main");
        }
        else if (scene == SCENE.Clear)
        {
            Invoke("RankingOn", 1.5f);
        }
    }

    void MusicStart(string sceneName)
    {
        SoundManager.instance.PlayBGM(sceneName);
    }

    public void TTM()
    {
        SceneMove.instance.TitleToMain();
    }

    public void CTT()
    {
        SceneMove.instance.ClearToTitle();
    }

    void RankingOn()
    {
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(GameManager.instance.score);
    }
}
