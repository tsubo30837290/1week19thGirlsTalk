using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Prime31.TransitionKit;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{
    public Texture2D maskTexture;

    public static SceneMove instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void TitleToMain()
    {
        SoundManager.instance.PlaySE(0);
        ImageMaskTransition mask = new ImageMaskTransition()
        {
            maskTexture = maskTexture,
            backgroundColor = new Color32(236,206,206,255),
            nextScene = SceneManager.GetActiveScene().buildIndex == 0 ? 1 : 0 // ?が if左==右だったらの役割、trueは：の左、falseが右の結果
        };
        TransitionKit.instance.transitionWithDelegate(mask);
    }

    public void MainToClear()
    {
        SoundManager.instance.PlaySE(0);
        ImageMaskTransition mask = new ImageMaskTransition()
        {
            maskTexture = maskTexture,
            backgroundColor = new Color32(236, 206, 206, 255),
            nextScene = SceneManager.GetActiveScene().buildIndex == 1 ? 2 : 1
        };
        TransitionKit.instance.transitionWithDelegate(mask);
    }

    public void ClearToTitle()
    {
        SoundManager.instance.PlaySE(0);
        ImageMaskTransition mask = new ImageMaskTransition()
        {
            maskTexture = maskTexture,
            backgroundColor = new Color32(236, 206, 206, 255),
            nextScene = SceneManager.GetActiveScene().buildIndex == 2 ? 0 : 2
        };
        TransitionKit.instance.transitionWithDelegate(mask);
    }
}
