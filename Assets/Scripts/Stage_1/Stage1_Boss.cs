using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1_Boss : MonoBehaviour
{
    float baseDir;
    public int count_max=5;
    private int reset=0;
    private int i = 0;
    

    public int hp = 1000;
    public GameObject enemy1;
    public GameObject ballets1_3;
    public GameObject ballets1_4;
    public GameObject ballets1_5;
    public GameObject ballets2_1;
    public GameObject ballets2_2;
    public GameObject denger;

    private HPBarController hpbc;


    IEnumerator Start()
    {
        yield return new WaitForSeconds(0.5f);
        hpbc = GameObject.Find("HPController").GetComponent<HPBarController>();
        int count = count_max;
        GetAim ga = new GetAim();

        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            baseDir = Random.Range(0,2);
                //Ai1
            Instantiate(ballets1_3, gameObject.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.8f);
            Instantiate(ballets1_4, gameObject.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.8f);
            Instantiate(ballets1_5, gameObject.transform.position, ga.getAimQua(gameObject.transform.position, GameObject.Find("player").transform.position));
            if (reset == 1)
            {
                count = 0;
            }
            if (count <= 0)
            {
                if (i == 0)
                {
                    if(reset == 1)
                    {
                        Instantiate(denger, new Vector3(1.5f, 0.0f, 0.0f), Quaternion.identity);
                        yield return new WaitForSeconds(2.0f);
                        Instantiate(ballets2_1, gameObject.transform.position, Quaternion.identity);
                        reset = 0;
                    }
                    i = 1;
                    Instantiate(enemy1, new Vector3(-1.4f, 5.0f, 0.0f), Quaternion.identity);
                }
                else
                {
                    if (reset == 1)
                    {
                        Instantiate(denger, new Vector3(-1.5f, 0.0f, 0.0f), Quaternion.identity);
                        yield return new WaitForSeconds(2.0f);
                        Instantiate(ballets2_2, gameObject.transform.position, Quaternion.identity);
                        reset = 0;
                    }
                    i = 0;
                    Instantiate(enemy1, new Vector3(1.4f, 5.0f, 0.0f), Quaternion.identity);
                    reset = 0;
                }
                count = count_max;
            }
            yield return new WaitForSeconds(0.8f);
            count--;
        }
    }
    public void count_reset()
    {
        reset = 1;
    }
}
