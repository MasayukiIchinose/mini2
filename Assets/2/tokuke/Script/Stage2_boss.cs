using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Stage2_boss : MonoBehaviour
{
    float baseDir;
    public int count_max = 5;
    private int reset = 0;
    private int i = 0;
    public float huguSpeed=0.01f;
    public float judge = -1.0f;
    public int stageJudge = 1;
    Slider hpslider;
    
   

    public int hp = 10000;
    public GameObject doku;
    public GameObject doku2;

    public float huguy;
    /*
    public GameObject ballets1_4;
    public GameObject ballets1_5;
    public GameObject ballets2_1;
    public GameObject ballets2_2;
    public GameObject denger;
    */

    private HPBarController hpbc;

    IEnumerator Start()
    {
        
        hpslider = GameObject.Find("Slider").GetComponent<Slider>();
        StartCoroutine(idou());
        stageJudge = 1;
         yield return new WaitForSeconds(0.5f);
        hpbc = GameObject.Find("HPController").GetComponent<HPBarController>();
        int count = count_max;
        GetAim ga = new GetAim();
        Debug.Log(stageJudge);
        
        while (true)
        {
           // Debug.Log(stageJudge);
        yield return new WaitForSeconds(1f); if (stageJudge == 2) { break; }
         Instantiate(doku, gameObject.transform.position, ga.getAimQua(gameObject.transform.position, GameObject.Find("player").transform.position));
        yield return new WaitForSeconds(1f); if (stageJudge == 2) { break; }
        Instantiate(doku, gameObject.transform.position, ga.getAimQua(gameObject.transform.position, GameObject.Find("player").transform.position));
        yield return new WaitForSeconds(1f); if (stageJudge == 2) { break; }
        Instantiate(doku, gameObject.transform.position, ga.getAimQua(gameObject.transform.position, GameObject.Find("player").transform.position));
        }
        
        while (true)
        {
            yield return new WaitForSeconds(1f);
            Instantiate(doku2, gameObject.transform.position, ga.getAimQua(gameObject.transform.position, GameObject.Find("player").transform.position));
            if (stageJudge == 3) { break; }
        }
       
    }
    void Update()
    {
        if (hpslider.value<=700&& hpslider.value >= 300)
        {
            stageJudge = 2;
        }
        if (hpslider.value <300)
        {
            stageJudge = 3;
        }
    }
   
    public IEnumerator idou()
    {
        while (true)
        {
            if (this.gameObject.transform.localPosition.x >= 1.60)
            {
                judge = -1.0f;
            }
            else if (this.gameObject.transform.localPosition.x <= -1.6)
            {
                judge = 1.0f;
            }
          
            transform.Translate(huguSpeed * judge, 0, 0);
            if (stageJudge==3)
            {
                break;
            }
            yield return null;
        }
        while (true)
        {
          
            Vector3 tmp = GameObject.Find("player").transform.position;
            Vector3 tmp2 = GameObject.Find("boss").transform.position;
            Debug.Log(tmp.x);
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(tmp.x,tmp2.y,tmp2.z), 3.0f);
            yield return new WaitForSeconds(1f);
        }
    }
}
   