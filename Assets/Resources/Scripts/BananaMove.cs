using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// バナナにつけるScript
public class BananaMove : MonoBehaviour
{
    float speed;

    [SerializeField] GameObject bananaUI;
    Slider bananaSlider;

    void Start()
    {
        speed = ParamsSO.Entity.bananaSpeed;
        bananaSlider = bananaUI.transform.Find("Banana Bar").GetComponent<Slider>();
        bananaSlider.value = 0f;
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

    public void UpdateValue()
    {
        if (bananaUI.activeSelf == false)
        {
            bananaUI.SetActive(true);
        }
        bananaSlider.value += 0.05f;
    }
}
