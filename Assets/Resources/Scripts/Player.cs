using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    //public float speed;

    [SerializeField] GameObject bulletPref; // トッピング弾
    [SerializeField] Sprite[] bulletSp; // 変更するための画像（配列）

    [SerializeField] Color32[] colors;

    void Start()
    {
        //speed = ParamsSO.Entity.playerSpeed;
    }

    void Update()
    {
        /*
        // 方向キーの入力された数値をxに入れる
        float x = Input.GetAxis("Horizontal");

        //右入力で右向きに動く
        if (x > 0)
        {
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        }
        //左入力で左向きに動く
        else if (x < 0)
        {
            transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
        }*/

        // もしスペースが押されたら
        // Input：入力に関すること（キー入力、マウス入力…）
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shot();
        }
    }

    void Shot()
    {
        // 弾を生成する
        GameObject bullet = Instantiate(bulletPref, transform.position, transform.rotation);

        // ランダムな数字を用意する
        int r = Random.Range(0, bulletSp.Length);

        // ランダムに色を変更する
        int n = Random.Range(0, colors.Length);

        // 画像をランダムにかえる
        bullet.GetComponent<SpriteRenderer>().sprite = bulletSp[r];
        bullet.GetComponent<SpriteRenderer>().color = colors[n];

        // 反動を与える
        transform.DOPunchPosition(
            new Vector3(0, -0.5f, 0), // パンチの方向と強さ
            0.1f                    // 演出時間
        ).OnComplete(() => transform.position = new Vector3(transform.position.x, -4, 0));
    }
}
