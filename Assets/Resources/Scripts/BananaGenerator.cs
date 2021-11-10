using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaGenerator : MonoBehaviour
{
    [SerializeField] GameObject[] banana;
    float interval;

    private void Start()
    {
        interval = ParamsSO.Entity.bananaInterval;
        StartCoroutine(BananaInstance());
    }

    IEnumerator BananaInstance()
    {
        while (!GameManager.instance.isFinish)
        {
            int r = Random.Range(0, banana.Length);
            // バナナを生成する(Instantiate)：何を、どこに、どの向きで
            Instantiate(banana[r], transform.position, transform.rotation);

            if (!GameManager.instance.feverTime)
            {
                yield return new WaitForSeconds(interval);
            }
            else
            {
                yield return new WaitForSeconds(interval / 3);
            }
        }
    }
}
