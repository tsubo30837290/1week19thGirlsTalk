using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;

    [SerializeField] GameObject bulletPref; // トッピング弾

    void Start()
    {
        speed = ParamsSO.Entity.playerSpeed;
    }

    void Update()
    {
        // 方向キーの入力された数値をxに入れる
        float x = Input.GetAxis("Horizontal");

        //右入力で右向きに動く
        if (x > 0)
        {
            transform.position += new Vector3(speed, 0, 0);
        }
        //左入力で左向きに動く
        else if (x < 0)
        {
            transform.position += new Vector3(-speed, 0, 0);
        }


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
        Instantiate(bulletPref, transform.position, transform.rotation);
    }
}
