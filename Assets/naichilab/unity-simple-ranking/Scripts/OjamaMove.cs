using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OjamaMove : MonoBehaviour
{
    // 0:ボディビル　1:メイド　2:呼び子
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
            yield return null;

            int r = Random.Range(0, 4);
            switch (r)
            {
                case 0:
                    yield return BodyBuilderMove();
                    yield return new WaitForSeconds(5);
                    break;
                case 1:
                    yield return MaidMove();
                    yield return new WaitForSeconds(5);
                    break;
                case 2:
                    yield return YobikoMove();
                    yield return new WaitForSeconds(5);
                    break;
            }
        }
    }

    IEnumerator BodyBuilderMove()
    {
        SoundManager.instance.PlaySE(2);
        GameObject ojama1 = Instantiate(ojamaChara[0], new Vector3(0, -1.5f, 0), transform.rotation);
        yield return new WaitForSeconds(5);

        Destroy(ojama1);
    }

    IEnumerator MaidMove()
    {
        SoundManager.instance.PlaySE(2);
        GameObject ojama2 = Instantiate(ojamaChara[1], new Vector3(-11, 0, 0), transform.rotation);

        ojama2.transform.DOMove(
        new Vector3(15, 0, 0),　　//移動後の座標
        7.0f 　　　　　　//時間
        )
            .OnComplete(() => Destroy(ojama2));
        yield return new WaitForSeconds(3);
    }

    IEnumerator YobikoMove()
    {
        SoundManager.instance.PlaySE(2);
        GameObject ojama3 = Instantiate(ojamaChara[2], new Vector3(12, -0.7f, 0), transform.rotation);

        ojama3.transform.DOMove(
        new Vector3(-16, -0.7f, 0),  //移動後の座標
        8.0f       //時間
        )
            .OnComplete(() => Destroy(ojama3));
        yield return new WaitForSeconds(3);
    }
}
