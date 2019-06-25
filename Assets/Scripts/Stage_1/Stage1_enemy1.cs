using System.Collections;
using UnityEngine;

public class Stage1_enemy1 : MonoBehaviour
{
    // 弾の移動スピード
    public GameObject bullets;
    public float interval = 1.0f;
    public int lifeTime = 15;
    public int speed = 1;

    public int hp = 5;

    IEnumerator Start()
    {
        Destroy(gameObject, lifeTime);
        while (true)
        {
            yield return new WaitForSeconds(interval);
            Instantiate(bullets, gameObject.transform.position, gameObject.transform.rotation);
        }
    }
    void OnTriggerEnter2D(Collider2D c)
    {
        // レイヤー名を取得
        string layerName = LayerMask.LayerToName(c.gameObject.layer);
        // レイヤー名がBullet (Player)以外の時は何も行わない
        if (layerName != "Bullet(p)") return;
        // 弾の削除
        Destroy(c.gameObject);
        hp--;

        //        Instantiate(explosion, transform.position, transform.rotation);

        if (hp <= 0)
        {
            GameObject.Find("Boss").GetComponent<Stage1_Boss>().count_reset();
            GameObject.Find("HPController").GetComponent<HPBarController>().damage(100);
            Destroy(gameObject);
            
        }
    }
}