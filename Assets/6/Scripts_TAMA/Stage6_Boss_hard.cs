using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage6_Boss_hard : MonoBehaviour
{


    public GameObject bulletPrefab;
    public GameObject playerObj;
    public GameObject hpController;
    public GameObject bulletsOya;

    private HPBarController hp;
    private int startHp;
    private bool startHpFlag = false;

    const double DISPLAY_LIFT = 2.4895f;
    const double DISPLAY_RIGHT = -2.81f;
    const double DISPLAY_TOP = 4.83986f;
    const double DISPLAY_BOTTOM = -4.8398f;

    //警告用関連
    public GameObject alertImageObj;
    private RectTransform alertImage;
    private bool alertTmpFlag = false;

    private int state = 1;
    private int state_b = 0;

    private double count = 0;//今のパターンの弾幕が始まってから何秒経過したか
    private double bulletStartCount = 0f;//今のパターンの弾幕が始まってから何秒経過したか（弾幕ループ時リセット） 

    private void Start()
    {
        alertImage = alertImageObj.GetComponent<RectTransform>();

        hp = hpController.GetComponent<HPBarController>();

        alertImageObj.SetActive(false);

        bulletsOya = GameObject.Find("bulletsOya");
    }
    // インスタンスを生成
    void Update()
    {
        if (!startHpFlag)
        {
            startHp = hp.rehp();
            Debug.Log(startHp);
            startHpFlag = true;
        }

        if (hp.rehp() < startHp / 2 && state == 1)
        {
            IncrimentState();
        }

        switch (state)
        {
            case 0:
                break;
            case 1:
                Pattern1();
                break;
            case 2:
                Pattern2();
                break;

        }
        bulletStartCount += Time.deltaTime;
        count += Time.deltaTime;
    }

    void IncrimentState()
    {
        //次の弾幕パターンに移るときはここを呼ぶ
        bulletStartCount = 0f;
        state++;
        state_b = 0;

        //警告終了
        alertImageObj.SetActive(false);
        alertTmpFlag = false;

        //弾を全部検索して全部消す
        var childTransform = GameObject.Find("bulletsOya").transform;

        foreach (Transform child in childTransform.transform)
        {
            Destroy(child.gameObject);


        }
    }

    public void InitBullet(Vector3 startPos, Vector3 startVectorI, Vector3 startVectorII, int dataId, int lifeTime)
    {
        //弾生成
        GameObject g = Instantiate(bulletPrefab, startPos, Quaternion.identity) as GameObject;

        //弾初期化
        if (lifeTime <= 0)
        {
            g.GetComponent<Bullet_TAMA>().InitBullet(startVectorI, startVectorII, dataId, bulletStartCount);
        }
        else
        {
            g.GetComponent<Bullet_TAMA>().InitBullet(startVectorI, startVectorII, dataId, lifeTime, bulletStartCount);
        }
        g.transform.parent = bulletsOya.transform;
    }

    void Pattern2()
    {
        if (state_b == 0 && bulletStartCount >= 1f)
        {
            //float k = Mathf.Atan2(playerObj.transform.position.y - this.transform.position.y, playerObj.transform.position.x - this.transform.position.x);

            float k = -Mathf.PI / 2;
            for (int i = 0; i < 7; i++)
            {
                float tmp = 0.05f;
                float ki = k + tmp * (i - 3);

                InitBullet(this.transform.position,
                    new Vector3(Mathf.Cos(ki) * Time.deltaTime * 3f, Mathf.Sin(ki) * Time.deltaTime * 3f, 0f),
                    new Vector3(0.0f, 0.0f, 0f)
                    , 2
                    , 20);

                state_b = 1;
            }
        }
        if (15 > bulletStartCount & bulletStartCount >= 12 & !alertTmpFlag)
        {
            //警告開始
            //alertImageObj.SetActive(true);
            //alertTmpFlag = true;
            //alertImage.sizeDelta = new Vector2(900, 800.65f);
            //alertImage.localPosition = new Vector3(0, -400.32f, 0);

        }
        if (bulletStartCount >= 15)
        {
            //警告終了
            //alertImageObj.SetActive(false);
            //alertTmpFlag = false;
        }

        if (bulletStartCount >= 20)
        {
            //パターン２弾幕1周期終了
            bulletStartCount = 0f;
            state_b = 0;
        }
    }

    private void Pattern1()
    {
        //弾幕パターン１
        if (bulletStartCount <= 5f)
        {
            for (int i = 0; i < 3; i++)
            {
                //上方向へのランダム弾幕生成
                InitBullet(new Vector3(this.gameObject.transform.position.x + Random.Range(-0.7f, 0.5f), this.gameObject.transform.position.y + Random.Range(-0.5f, 0.5f), 0),
                    new Vector3(Random.Range(-0.05f, 0.05f), 0.05f, 0f),
                    new Vector3(0.0f, -0.00025f, 0f)
                    , 1
                    , 20);
            }
        }
        if (12 > bulletStartCount & bulletStartCount >= 9 & !alertTmpFlag)
        {
            //警告開始
            // alertImageObj.SetActive(true);
            // alertTmpFlag = true;



            // alertImage.sizeDelta = new Vector2(900, 570.1f);
            // alertImage.localPosition = new Vector3(0, -515.6f, 0);
        }
        if (bulletStartCount >= 12)
        {
            //警告終了
            //  alertImageObj.SetActive(false);
            //  alertTmpFlag = false;
        }
        if (bulletStartCount >= 20)
        {
            //パターン１弾幕1周期終了
            bulletStartCount = 0f;
            state_b = 0;
        }
    }
}
