using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaGenerator : MonoBehaviour
{
    [SerializeField] GameObject banana;

    private void Start()
    {
        StartCoroutine(BananaInstance());
    }

    IEnumerator BananaInstance()
    {
        while (true)
        {
            // バナナを生成する(Instantiate)：何を、どこに、どの向きで
            Instantiate(banana, transform.position, transform.rotation);
            yield return new WaitForSeconds(3);
        }
    }
}
