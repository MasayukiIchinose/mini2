using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss1 : MonoBehaviour
{
    float baseDir;
    public int hp = 1000;
    public GameObject bullets1;
    public GameObject bullets1_;
    public GameObject bullets2;
    public GameObject bullets2_;
    public GameObject bullets3;

    private HPBarController hpbc;


    IEnumerator Start()
    {
        yield return new WaitForSeconds(0.5f);
        hpbc = GameObject.Find("HPController").GetComponent<HPBarController>();

        while (true)
        {
            if ((hpbc.rehp() * 100 / hp) > 50)
            {
                //Ai1
                Instantiate(bullets1, gameObject.transform.position, Quaternion.identity);
                yield return new WaitForSeconds(2.5f);
                Instantiate(bullets1_, gameObject.transform.position, Quaternion.identity);
                yield return new WaitForSeconds(2.6f);
            }

            //Ai2
            else
            {
                Instantiate(bullets2, gameObject.transform.position, Quaternion.identity);
                yield return new WaitForSeconds(5.0f);
                Instantiate(bullets2_, gameObject.transform.position, Quaternion.identity);
                yield return new WaitForSeconds(2.0f);
                Instantiate(bullets3, gameObject.transform.position, Quaternion.identity);
                yield return new WaitForSeconds(1.5f);
            }
        }
    }
}