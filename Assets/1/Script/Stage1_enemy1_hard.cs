using System.Collections;
using UnityEngine;

public class Stage1_enemy1_hard : MonoBehaviour
{
    // 弾の移動スピード
    public GameObject bullets;
    public float interval = 1.0f;
    public int lifeTime = 15;
    public int speed = 1;
    public int hp = 5;

    IEnumerator Start()
    {
        GetAim ga = new GetAim();
        Destroy(gameObject, lifeTime);
        while (true)
        {
            yield return new WaitForSeconds(interval);
            Instantiate(bullets, gameObject.transform.position, ga.getAimQua(gameObject.transform.position, GameObject.Find("player").transform.position));
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
            GameObject.Find("Boss").GetComponent<Stage1_Boss_hard>().count_reset();
            GameObject.Find("HPController").GetComponent<HPBarController>().damage(100);
            Destroy(gameObject);

        }
    }
}