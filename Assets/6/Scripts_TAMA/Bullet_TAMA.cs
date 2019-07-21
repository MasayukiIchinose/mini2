using UnityEngine;

public class Bullet_TAMA : MonoBehaviour
{
    const double DISPLAY_RIGHT = 2.4895f;
    const double DISPLAY_LIFT = -2.81f;
    const double DISPLAY_TOP = 4.83986f;
    const double DISPLAY_BOTTOM = -4.8398f;

    public GameObject playerObj;
    public GameObject bulletsOya;

    private Vector3 vi;//速度成分
    private Vector3 vii;//加速度成分

    private float ofsetSpeedVi=1f;//速度成分のバイアス
    private float ofsetSpeedVii = 1f;//加速度成分のバイアス

    private double lifeTime;//寿命
    private double oldTime;//弾が生まれてからの時間
    public double startCountTime;//今の弾幕の最初の弾が飛んでからの時間
    private int state;//弾の現在のステート

    private int iroiro;//いろんな使い捨て変数

    public int dataId;
    void Start()
    {
        bulletsOya = GameObject.Find("bulletsOya");
    }

    void Update()
    {
       

        lifeTime -= Time.deltaTime;
        if (lifeTime < 0)
        {
            Destroy(this.gameObject);//時間経過で弾を消す
        }

        oldTime += Time.deltaTime;
        switch (dataId)
        {
            case 1:
                patternID1();
                break;
            case 2:
                patternID2();
                break;
        }


        vi += vii*ofsetSpeedVii;//速度に加速度を加算

        gameObject.transform.Translate(vi*ofsetSpeedVi);//弾の座標に速度を加算
    }

    //弾から弾を増やすとき使う
    public void InitBullet(Vector3 startPos, Vector3 startVectorI, Vector3 startVectorII, int dataId, int lifeTime)
    {
        //弾生成
        GameObject g = Instantiate(gameObject, startPos, Quaternion.identity) as GameObject;
        
        //弾初期化
        if (lifeTime <= 0)
        {
            g.GetComponent<Bullet_TAMA>().InitBullet(startVectorI, startVectorII, dataId, this.startCountTime+oldTime);
        }
        else
        {
            g.GetComponent<Bullet_TAMA>().InitBullet(startVectorI, startVectorII, dataId, lifeTime, this.startCountTime + oldTime);
        }
        g.transform.parent=bulletsOya.transform;
    }

    public void InitBullet(Vector3 startVectorI, Vector3 startVectorII, int dataId ,double bulletStartCount)
    {
        vi = startVectorI;
        vii = startVectorII;
        this.dataId = dataId;
        this.startCountTime = bulletStartCount;

        lifeTime = 10f;
        oldTime = 0f;
        state = 0;

        playerObj = GameObject.Find("player");
    }
    public void InitBullet(Vector3 startVectorI, Vector3 startVectorII, int dataId ,int lifetime ,double bulletStartCount)
    {
        vi = startVectorI;
        vii = startVectorII;
        this.dataId = dataId;
        this.lifeTime = lifetime;
        this.startCountTime = bulletStartCount;
        oldTime = 0f;
        state = 0;
        playerObj = GameObject.Find("player");
    }
    public void patternID2()
    {
        if (iroiro < 0 && state < 2 & 16f > startCountTime + oldTime)
        {
            //Debug.Log(vi.x+"  ,  "+vi.y);
            if (transform.position.y <= DISPLAY_BOTTOM)
            {
                state++;
                vi.y *= -1f;

                iroiro = 10;

                if (1 < oldTime)
                {
                    Vector3 tmpvi = new Vector3(-vi.x * Random.Range(0.9f, 1.2f) , vi.y * Random.Range(0.9f, 1.2f), 0);
                    InitBullet(
                        transform.position,
                        tmpvi,
                        Vector3.zero,
                        2,
                        20);
                }

            }
            else if (transform.position.y >= DISPLAY_TOP)
            {
                state++;
                vi.y *= -1f;

                iroiro = 10;

                if (1 < oldTime)
                {
                    Vector3 tmpvi = new Vector3(-vi.x * Random.Range(0.9f, 1.2f) , vi.y * Random.Range(0.9f, 1.2f), 0);
                    InitBullet(
                        transform.position,
                        tmpvi,
                        Vector3.zero,
                        2,
                        20);
                }
            }

            if (transform.position.x <= DISPLAY_LIFT)
            {
                state++;
                vi.x *= -1f;
                iroiro = 10;

                if (1 < oldTime)
                {
                    Vector3 tmpvi = new Vector3(vi.x * Random.Range(0.9f, 1.2f) , -vi.y + Random.Range(-0.002f, 0.002f), 0);
                    InitBullet(
                        transform.position,
                        tmpvi,
                        Vector3.zero,
                        2,
                        20);
                }
            }
            else if (transform.position.x >= DISPLAY_RIGHT)
            {
                state++;
                vi.x *= -1f;
                iroiro = 10;

                if (1 < oldTime)
                {
                    Vector3 tmpvi = new Vector3(vi.x * Random.Range(0.9f, 1.2f) , -vi.y + Random.Range(-0.002f, 0.002f), 0);
                    InitBullet(
                        transform.position,
                        tmpvi,
                        Vector3.zero,
                        2,
                        20);
                }
            }
        }
        else
        {
            if (state >= 2)
            {


            }
            iroiro--;
        }

        //Debug.Log(startCountTime + oldTime);
        if (15.5f > startCountTime + oldTime & startCountTime + oldTime > 15f & state<10)
        {
            double tmp = DISPLAY_BOTTOM+(DISPLAY_TOP-DISPLAY_BOTTOM)/2;//真ん中の座標
            //Debug.Log(DISPLAY_BOTTOM+"<="+this.gameObject.transform.position.y+"<="+tmp);
            if (DISPLAY_BOTTOM<= transform.position.y & transform.position.y <= tmp)
            {

               
                iroiro = 10000;
                //高速真横に飛ぶ弾にする
                if (Random.Range(0,2)==0)
                {
                    vi.x = 0.2f;
                    vi.y = 0f;
                    vi.z = 0f;
                    vii = vi * 0.03f;
                    
                }
                else
                {
                    vi.x = -0.2f;
                    vi.y = 0f;
                    vi.z = 0f;
                    vii = vi * 0.03f;
                }
                lifeTime = 2f;
                state = 10;
            }
        }

        if (16f < startCountTime + oldTime)
        {
            if (state < 10)
            {
                //他は自機狙いにしてしまう
                float k = Mathf.Atan2(playerObj.transform.position.y - this.transform.position.y, playerObj.transform.position.x - this.transform.position.x);
                vi.x = Mathf.Cos(k) * Time.deltaTime;
                vi.y = Mathf.Sin(k) * Time.deltaTime;
                vi.z = 0f;

                vii = vi * 0.01f;
                state = 20;
                lifeTime = 7f;
            }

        }
    }
    public void patternID1()
    {
        //第一形態の上から降り注ぐ弾幕

        if (startCountTime+oldTime>12f & state==0) {

            if (DISPLAY_BOTTOM-50f<=transform.position.y & transform.position.y<= DISPLAY_BOTTOM+3f)
            {
                //画面下部を高速真横に飛ぶ弾にする
                if (transform.position.x <= DISPLAY_LIFT) {
                    vi.x = 0.2f;
                    vi.y = 0f;
                    vi.z = 0f;
                    vii = vi * 0.03f;
                }
                else if(DISPLAY_RIGHT<=transform.position.x)
                {
                    vi.x = -0.2f;
                    vi.y = 0f;
                    vi.z = 0f;
                    vii = vi * 0.03f;
                }
            }
            else
            {
                //他は自機狙いにしてしまう
                float k = Mathf.Atan2(playerObj.transform.position.y - this.transform.position.y, playerObj.transform.position.x - this.transform.position.x);
                vi.x = Mathf.Cos(k) * Time.deltaTime;
                vi.y = Mathf.Sin(k) * Time.deltaTime;
                vi.z = 0f;

                vii = vi * 0.01f;
                //ofsetSpeedVii
            }

            state = 1;
        }

    }
}