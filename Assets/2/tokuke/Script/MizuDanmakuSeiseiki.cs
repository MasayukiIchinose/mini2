using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MizuDanmakuSeiseiki : MonoBehaviour
{
    public GameObject sakana;
    public float mizuTime=1f;
    public float rand;
    public float time;
    public int judge = -1;
    public float seiseikiSpeed = 0.5f;
    public int count = 0;

    IEnumerator Start()
    {
        StartCoroutine(DanmakuIdou());
        while (true)
        {
            rand = Random.Range(1.0f,2.0f );
            yield return new WaitForSeconds(rand);
            Instantiate(sakana, gameObject.transform.position, Quaternion.identity);
        }
    }
    public IEnumerator DanmakuIdou()
    {
        while (true)
        {

            transform.Translate(0, seiseikiSpeed * judge, 0);
            yield return new WaitForSeconds(1);
            count++;
            if (count == 5)
            {
                judge *= -1;
                count = 0;
            }
        }
    }
}
