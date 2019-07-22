using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mizuDanmaku_hard : MonoBehaviour
{
    // 弾の移動スピード
    public int speed = 5;
    public float lifeTime = 5;
    public float rad = 0;
    public int mizujudge;
    public int mizujudge2;
    public Stage2_boss stage2_mizu;
    public GameObject hugu;
    public Transform m_target = null;
    private float m_speed = 2;
    public float m_attenuation = 0.5f;

    private Vector3 m_velocity;
    void Start()
    {
       
         hugu = GameObject.Find("boss").gameObject;
         m_target = hugu.GetComponent<Transform>();
        mizujudge=hugu.GetComponent<Stage2_boss_hard>().stageJudge;
       

        if (mizujudge == 1)
         {

             // ローカル座標のY軸方向に移動する
             if (this.gameObject.transform.localPosition.x <= -4.0f)
             {
                 GetComponent<Rigidbody2D>().velocity = transform.right.normalized * speed;
             }
             else if (this.gameObject.transform.localPosition.x >= 1.8f)
             {
                 GetComponent<Rigidbody2D>().velocity = transform.right.normalized * speed * -1;
             }
             else if (this.gameObject.transform.localPosition.x <= 1.8f&& this.gameObject.transform.localPosition.x >= -4.0f)
            {
                GetComponent<Rigidbody2D>().velocity = transform.right.normalized * speed * -1;
            }
         }
        if (mizujudge == 3)
        {
            Destroy(this);
        }

            // lifeTime秒後に削除
            Destroy(gameObject, lifeTime);
    }
   
    void Update()
    {
        if (mizujudge == 2)
        {
            m_velocity += (m_target.position - transform.position) * m_speed;
            m_velocity *= m_attenuation;
            transform.position += m_velocity *= Time.deltaTime;

        }
    }

}
