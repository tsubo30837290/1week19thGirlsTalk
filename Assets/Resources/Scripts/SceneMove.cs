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
            backgroundColor = Color.yellow,
            nextScene = SceneManager.GetActiveScene().buildIndex == 4 ? 5 : 4
        };
        TransitionKit.instance.transitionWithDelegate(mask);
    }
}
