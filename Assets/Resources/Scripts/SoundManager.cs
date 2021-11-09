using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSourceBGM;
    public AudioClip[] audioClipsBGM;
    public AudioSource audioSourceSE;
    public AudioClip[] audioClipsSE;

    public void StopBGM()
    {
        audioSourceBGM.Stop();
    }

    public static SoundManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayBGM(string sceneName)
    {
        audioSourceBGM.Stop();

        switch (sceneName)
        {
            default:

            case "Title":
                audioSourceBGM.clip = audioClipsBGM[0];
                break;
            case "Main":
                audioSourceBGM.clip = audioClipsBGM[1];
                break;
            case "Fever":
                audioSourceBGM.clip = audioClipsBGM[2];
                break;
            case "HighScoreClear":
                audioSourceBGM.clip = audioClipsBGM[3];
                break;
            case "NormalClear":
                audioSourceBGM.clip = audioClipsBGM[3];
                break;
        }
        audioSourceBGM.Play();
    }

    public void PlaySE(int index)
    {
        audioSourceSE.PlayOneShot(audioClipsSE[index]);
    }
}