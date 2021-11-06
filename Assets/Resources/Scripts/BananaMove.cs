using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// バナナにつけるScript
public class BananaMove : MonoBehaviour
{
    float speed;

    void Start()
    {
        speed = ParamsSO.Entity.bananaSpeed;
    }

    void Update()
    {
        transform.position += new Vector3(speed, 0, 0);

        // もしバナナが-10より左に移動したら
        if (transform.position.x <= -10)
        {
            // バナナ（自分自身）を消してね
            Destroy(gameObject);
        }
    }
}
