using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bullet : MonoBehaviour
{
    public float speed;
    bool hit;

    SpriteRenderer sr;
    GameObject target;
    Vector3 targetPos;

    void Start()
    {
        // 向かう目標地点
        target = GameObject.Find("Target");
        targetPos = target.transform.position - transform.position;

        sr = GetComponent<SpriteRenderer>();
        speed = ParamsSO.Entity.bulletSpeed;

        //ShotMove();
    }

    void Update()
    {
        if (!hit)
        {
            //transform.position += new Vector3(0, speed, speed) * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position + 100 * targetPos, speed * Time.deltaTime);

            // もし弾が6より上に移動したら
            if (transform.position.y >= 20)
            {
                // 弾（自分自身）を消してね
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        // バナナに当たったら
        if (collision.gameObject.tag == "Banana")
        {
            //StartCoroutine(Hit(collision));
            hit = true;
            gameObject.transform.parent = collision.gameObject.transform;

            collision.gameObject.GetComponent<BananaMove>().UpdateValue();
        }
    }

    /*
    void ShotMove()
    {
        // サイズを1 → 0.5に少しずつする
        transform.DOScale(
            new Vector3(0.5f, 0.5f, 1),  //終了時点のScale
            0.5f       //時間
            ) ;

        // 徐々にフェードさせる（α値を下げる）
        DOTween.ToAlpha(() => sr.color,
        a => sr.color = a, 0.0f, 0.2f);
    }*/

    /*
    IEnumerator Hit(Collider2D collision)
    {
        //float r = Random.Range(0, 0.01f);
        //yield return new WaitForSeconds(r);

        DOTween.ToAlpha(() => sr.color,
        a => sr.color = a, 1.0f, 0.1f);

        hit = true;
        gameObject.transform.parent = collision.gameObject.transform;

        collision.gameObject.GetComponent<BananaMove>().UpdateValue();
        yield return null;
    }*/
}
