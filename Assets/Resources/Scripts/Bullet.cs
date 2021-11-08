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
        // サイズを1 → 0.5に少しずつする
        transform.DOScale(
            new Vector3(0.5f, 0.5f, 1),  //終了時点のScale
            0.5f       //時間
            ) ;

        // 徐々にフェードさせる（α値を下げる）
        DOTween.ToAlpha(() => sr.color,
        a => sr.color = a, 0.0f, 0.2f)
            .OnComplete(()=> Hit());
    }

    void Hit()
    {
        hit = true;

        gameObject.transform.position = target.transform.position;

        DOTween.ToAlpha(() => sr.color,
        a => sr.color = a, 1.0f, 0.1f);

        RaycastHit2D[] hits = Physics2D.CircleCastAll(gameObject.transform.position, 0.4f, Vector2.zero);
        List<RaycastHit2D> hitList = hits.ToList();

        RaycastHit2D banana = hitList.Find(b => b.collider.tag == "Banana");
        RaycastHit2D wall = hitList.Find(b => b.collider.tag == "Wall");
        if (banana)
        {
            gameObject.transform.parent = banana.collider.gameObject.transform;
            banana.collider.gameObject.GetComponent<BananaMove>().UpdateValue();
        }
        else if (wall)
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        DOTween.KillAll();
    }
}
