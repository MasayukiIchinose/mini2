using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    Unit unit;

    IEnumerator Start()
    {
        // Spaceshipコンポーネントを取得
        unit = GetComponent<Unit>();

        while (true)
        {
            // 弾をプレイヤーと同じ位置/角度で作成
            unit.Shot(transform);

            // shotDelay秒待つ
            yield return new WaitForSeconds(unit.shotDelay);
        }
    }
    void Update()
    {
        /*       // 右・左
               float x = Input.GetAxisRaw("Horizontal");

               // 上・下
               float y = Input.GetAxisRaw("Vertical");

               // 移動する向きを求める
               Vector2 direction = new Vector2(x, y).normalized;

               // 移動
               unit.Move(direction);*/
        Clamp();
    }

    // ぶつかった瞬間に呼び出される
    void OnTriggerEnter2D(Collider2D c)
    {
        // レイヤー名を取得
        string layerName = LayerMask.LayerToName(c.gameObject.layer);

        // レイヤー名がBullet (Enemy)の時は弾を削除
        if (layerName == "Bullet(e)")
        {
            // 弾の削除
            Destroy(c.gameObject);
        }

        // レイヤー名がBullet (Enemy)またはEnemyの場合は爆発
        if (layerName == "Bullet(e)" || layerName == "Enemy")
        {
            // 爆発する
 //           unit.Explosion();

            // プレイヤーを削除
            Destroy(gameObject);
            GameObject.Find("HPController").GetComponent<ScoreManager>().backScene();
        }
    }
    void Clamp()
    {
        // 画面左下のワールド座標をビューポートから取得
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        // 画面右上のワールド座標をビューポートから取得
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        // プレイヤーの座標を取得
        Vector2 pos = transform.position;

        // プレイヤーの位置が画面内に収まるように制限をかける
        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        // 制限をかけた値をプレイヤーの位置とする
        transform.position = pos;
    }
}