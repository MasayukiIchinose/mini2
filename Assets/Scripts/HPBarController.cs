using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBarController : MonoBehaviour
{

    GameObject boss;
    Slider hpslider;
    public int maxhp=1000;
    private int hp;

    void Start()
    {

        hpslider = GameObject.Find("Slider").GetComponent<Slider>();
        hp = maxhp;
        hpslider.value = hp;
    }
    void Update()
    {
            hpslider.value = hp;
        if(hp<=0)
        {
            GameObject.Find("HPController").GetComponent<ScoreManager>().setScore();
        }
    }
    public int damage(int value)
    {
        hp -= value;
        return hp;
    }
    public int rehp()
    {
        return hp;
    }
    
}