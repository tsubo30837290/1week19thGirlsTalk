using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Prime31.TransitionKit;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{
    public Texture2D maskTexture;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void TitleToMain()
    {
        ImageMaskTransition mask = new ImageMaskTransition()
        {
            maskTexture = maskTexture,
            backgroundColor = new Color32(236,206,206,255),
            nextScene = SceneManager.GetActiveScene().buildIndex == 1 ? 2 : 1
        };
        TransitionKit.instance.transitionWithDelegate(mask);
    }
}
