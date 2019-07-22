using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Stage2_boss_hard : MonoBehaviour
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
    public GameObject mizu;
    public GameObject kani;
    public float huguy;
   

    private HPBarController hpbc;

    IEnumerator Start()
    {
        kani = GameObject.Find("kani");
        hpslider = GameObject.Find("Slider").GetComponent<Slider>();
        StartCoroutine(idou());
        stageJudge = 1;
         yield return new WaitForSeconds(0.5f);
        hpbc = GameObject.Find("HPController").GetComponent<HPBarController>();
        int count = count_max;
       
        yield return StartCoroutine(Wave1());
        yield return StartCoroutine(Wave2());
        yield return StartCoroutine(Wave3());

    }
    void Update()
    {
        if (hpslider.value<=700&& hpslider.value >= 400)
        {
            stageJudge = 2;
        }
        if (hpslider.value <400)
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
        
    }
    public IEnumerator Wave1()
    {
        GetAim ga = new GetAim();
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
    }
    public IEnumerator Wave2()
    {
        
        while (true)
        {
            if (stageJudge == 3) { break; }
            yield return new WaitForSeconds(1f);
            //Instantiate(doku2, gameObject.transform.position, ga.getAimQua(gameObject.transform.position, GameObject.Find("player").transform.position));
        }
        Debug.Log("呼ばれた");
    }
    public IEnumerator Wave3()
    {
        GetAim ga = new GetAim();
        int time = 0;
        kani.GetComponent<KaniDanmakuMove>().KaniStart();
        //Debug.Log("呼ばれた2");
        while (true) {
            time = 0;
            Vector3 tmp = GameObject.Find("player").transform.position;
            Vector3 tmp2 = GameObject.Find("boss").transform.position;
            yield return new WaitForSeconds(1f);
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(tmp.x, tmp2.y, tmp2.z), 3.0f);
            
            while (time<=40) {
                Instantiate(mizu, gameObject.transform.position, ga.getAimQua(gameObject.transform.position, GameObject.Find("player").transform.position));
                time += 1;
                yield return new WaitForSeconds(0.1f);
            }
        }
    }

}
   