using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// バナナにつけるScript
public class BananaMove : MonoBehaviour
{
    float speed;

    [SerializeField] GameObject bananaUI;
    public Slider bananaSlider;

    [SerializeField] Sprite[] chocoSprite;
    [SerializeField] Sprite[] stickSprite;

    [SerializeField] GameObject choco;
    [SerializeField] GameObject stick;

    void Start()
    {
        SpriteChange();
        speed = ParamsSO.Entity.bananaSpeed;
        bananaSlider = bananaUI.transform.Find("Banana Bar").GetComponent<Slider>();
        bananaSlider.value = 0f;
    }

    void Update()
    {
        transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;

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

        // もしバナナのゲージがMaxだったら → スコアを加算する
        if (bananaSlider.value >= 1)
        {
            // Score加算
            GameManager.instance.UpdateScoreUI();
        }
        // そうじゃなかったらバナナゲージを加算する
        else
        {
            // ゲージを上げる
            bananaSlider.value += ParamsSO.Entity.bananaHitGauge;
        }
    }

    void SpriteChange()
    {
        int chocoN = Random.Range(0, chocoSprite.Length);
        choco.GetComponent<SpriteRenderer>().sprite = chocoSprite[chocoN];

        int stickN = Random.Range(0, stickSprite.Length);
        stick.GetComponent<SpriteRenderer>().sprite = stickSprite[stickN];
    }
}
