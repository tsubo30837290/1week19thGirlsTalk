using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;

public class Bullet : MonoBehaviour
{
    public float speed;
    bool hit;

    SpriteRenderer sr;
    GameObject target;
    Vector3 targetPos;

    Tween tween;
    Tween tween2;
    Tween tween3;

    public bool smallParts;

    public Vector3 offset;

    void Start()
    {
        // 向かう目標地点
        target = GameObject.Find("Target");
        targetPos = target.transform.position - transform.position;

        sr = GetComponent<SpriteRenderer>();
        speed = ParamsSO.Entity.bulletSpeed;

        ShotMove();
    }

    void Update()
    {
        if (!hit)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position + 100 * targetPos, speed * Time.deltaTime);
        }
    }

    void ShotMove()
    {
        if (!GameManager.instance.feverTime)
        {
            // サイズを1 → 0.5に少しずつする
            tween = transform.DOScale(
                new Vector3(0.5f, 0.5f, 1),  //終了時点のScale
                0.5f       //時間
                );
        }
        else
        {
            if (!smallParts)
            {
                // サイズを1 → 0.5に少しずつする
                tween = transform.DOScale(
                    new Vector3(0.4f, 0.4f, 1),  //終了時点のScale
                    0.5f       //時間
                    );
            }
        }

        // 徐々にフェードさせる（α値を下げる）
        tween2 = DOTween.ToAlpha(() => sr.color,
        a => sr.color = a, 0.0f, 0.2f)
            .OnComplete(()=> Hit());
    }

    void Hit()
    {
        hit = true;

        gameObject.transform.position = target.transform.position + offset;

        tween3 = DOTween.ToAlpha(() => sr.color,
        a => sr.color = a, 1.0f, 0.1f);

        RaycastHit2D[] hits = Physics2D.CircleCastAll(gameObject.transform.position, 0.4f, Vector2.zero);
        List<RaycastHit2D> hitList = hits.ToList();

        RaycastHit2D banana = hitList.Find(b => b.collider.tag == "Banana");
        RaycastHit2D wall = hitList.Find(b => b.collider.tag == "Wall");
        RaycastHit2D ojama = hitList.Find(b => b.collider.tag == "Ojama");
        RaycastHit2D yobiko = hitList.Find(b => b.collider.tag == "Yobiko");
        RaycastHit2D bbuilder = hitList.Find(b => b.collider.tag == "BodyBuilder");

        if (bbuilder)
        {
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = 32;
            gameObject.transform.parent = bbuilder.collider.gameObject.transform;
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            Destroy(gameObject, 4f);
        }
        else if (yobiko)
        {
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = 28;
            gameObject.transform.parent = yobiko.collider.gameObject.transform;
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            Destroy(gameObject, 4f);
        }
        else if (ojama)
        {
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = 24;
            gameObject.transform.parent = ojama.collider.gameObject.transform;
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            Destroy(gameObject, 4f);
        }

        else if (banana)
        {
            gameObject.transform.parent = banana.collider.gameObject.transform;
            banana.collider.gameObject.GetComponent<BananaMove>().UpdateValue();
        }
        else if (wall)
        {
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = -1;
            Destroy(gameObject, 2f);
        }
    }

    private void OnDestroy()
    {
        //DOTween.Kill(transform);
        tween.Kill();
        tween2.Kill();
        tween3.Kill();
    }
}
