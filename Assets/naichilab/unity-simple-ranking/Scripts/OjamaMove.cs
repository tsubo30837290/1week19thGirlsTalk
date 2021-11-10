using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OjamaMove : MonoBehaviour
{
    [SerializeField] GameObject[] ojamaChara;

    void Start()
    {
        StartCoroutine(GoGoOjama());
    }

    IEnumerator GoGoOjama()
    {
        yield return new WaitForSeconds(5);

        while (!GameManager.instance.isFinish)
        {
        }
    }
}
