using UnityEngine;

public class DokuBullet : MonoBehaviour
{
    // 弾の移動スピード
    public int speed = 3;

    // ゲームオブジェクト生成から削除するまでの時間
    public float lifeTime2 = 4;

    public float rad = 0;

    void Start()
    {
        // ローカル座標のY軸方向に移動する
        GetComponent<Rigidbody2D>().velocity = transform.up.normalized * speed;

        // lifeTime秒後に削除
        Destroy(gameObject, lifeTime2);
    }
}