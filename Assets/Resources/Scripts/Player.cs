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

    [SerializeField] SpriteRenderer shoot;
    [SerializeField] Color32[] shootColors;
    [SerializeField] Color32[] shootColorsSide;

    [SerializeField] Sprite[] decoSp;

    public enum TYPE
    {
        small,
        big,
    }
    public TYPE type = TYPE.small;

    void Start()
    {
        int c = Random.Range(0, shootColors.Length);

        if (type == TYPE.small)
        {
            shoot.color = shootColors[c];
        }
        else
        {
            shoot.color = shootColors[c];
            foreach (Transform child in gameObject.transform)
            {
                if (child.gameObject.name == "handleBG")
                {
                    child.gameObject.GetComponent<SpriteRenderer>().color = shootColorsSide[c];
                }
            }
        }
    }

    void Update()
    {
        if (!GameManager.instance.isFinish)
        {
            if (!GameManager.instance.feverTime)
            {
                // もしスペースが押されたら
                // Input：入力に関すること（キー入力、マウス入力…）
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Shot();
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    SpecialShot();
                }
            }
        }
    }

    void Shot()
    {
        SoundManager.instance.PlaySE(1);
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

    void SpecialShot()
    {
        SoundManager.instance.PlaySE(1);

        BulletInstance(new Vector3(0, 0, 0));

        for (int i = 0; i < 20; i++)
        {
            float x = Random.Range(-0.8f, 0.8f);
            float y = Random.Range(-0.8f, 0.8f);
            BulletInstance(new Vector3(x, y, 0));
        }

        // 反動を与える
        transform.DOPunchPosition(
            new Vector3(0, -0.5f, 0), // パンチの方向と強さ
            0.1f                    // 演出時間
        ).OnComplete(() => transform.position = new Vector3(transform.position.x, -4, 0));
    }

    void BulletInstance(Vector3 offset)
    {
        // 弾を生成する
        GameObject bullet = Instantiate(bulletPref, transform.position, transform.rotation);

        bullet.GetComponent<Bullet>().offset = offset;

        // ランダムな数字を用意する
        int r = Random.Range(0, decoSp.Length);

        if (r > 4)
        {
            bullet.GetComponent<Bullet>().smallParts = true;
            bullet.GetComponent<SpriteRenderer>().sortingOrder -= 1;
        }

        // 画像をランダムにかえる
        bullet.GetComponent<SpriteRenderer>().sprite = decoSp[r];
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.DrawSphere(Vector3.zero,0.4f);
    //}
}
