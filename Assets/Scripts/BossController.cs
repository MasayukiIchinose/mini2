using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    //一撃当たり受けるダメージ量
    //本来なら弾の威力で渡したかった…
    public int damage = 100;
    //HPBarControllerの取得用
    private HPBarController hpbc;
    // 爆発のPrefab
    public GameObject explosion;

    void Start()
    {
        //hpbcの取得
        hpbc = GameObject.Find("HPController").GetComponent<HPBarController>();
    }

    // 被弾時の処理
    void OnTriggerEnter2D(Collider2D c)
    {
        // レイヤー名を取得
        string layerName = LayerMask.LayerToName(c.gameObject.layer);
        // レイヤー名がBullet (Player)以外の時は何も行わない
        if (layerName != "Bullet(p)") return;
        // 弾の削除
        Destroy(c.gameObject);
        
        if (hpbc.damage(damage) <= 0)
        {
            //        Instantiate(explosion, transform.position, transform.rotation);


            Destroy(gameObject);
        }
    }
}
