using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMarker : MonoBehaviour
{
    public float speed;
    [SerializeField] Sprite[] targetSp;
    [SerializeField] Color32[] colors;

    void Start()
    {
        speed = ParamsSO.Entity.playerSpeed;
        TargetSet();
    }

    void Update()
    {
        // 方向キーの入力された数値をxに入れる
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        // 右入力で右向きに動く
        if (x > 0)
        {
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        }

        // 左入力で左向きに動く
        if (x < 0)
        {
            transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
        }

        // 上
        if (y > 0)
        {
            transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
        }

        // 下
        if (y < 0)
        {
            transform.position += new Vector3(0, -speed, 0) * Time.deltaTime;
        }
    }

    void TargetSet()
    {
        int n = Random.Range(0, targetSp.Length);
        int r = Random.Range(0, colors.Length);

        GetComponent<SpriteRenderer>().sprite = targetSp[n];
        GetComponent<SpriteRenderer>().color = colors[r];
    }
}
