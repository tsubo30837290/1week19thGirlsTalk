using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;

    void Start()
    {
        speed = ParamsSO.Entity.bulletSpeed;
    }

    void Update()
    {
        transform.position += new Vector3(0, speed, 0);

        // もし弾が6より上に移動したら
        if (transform.position.y >= 6)
        {
            // 弾（自分自身）を消してね
            Destroy(gameObject);
        }
    }
}
