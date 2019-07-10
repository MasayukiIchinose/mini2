using UnityEngine;

public class SakanaMove: MonoBehaviour
{
    // 弾の移動スピード
    public int speed = 10;

    // ゲームオブジェクト生成から削除するまでの時間
    public float lifeTime = 5;

    public float rad = 0;

    void Start()
    {
        //Vector3 scale = transform.localScale;
        if (this.gameObject.transform.localPosition.x <= -4.0f)
        {
           
            transform.localScale =
  new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
        // ローカル座標のY軸方向に移動する
        if (this.gameObject.transform.localPosition.x <= -4.0f) {
            GetComponent<Rigidbody2D>().velocity = transform.right.normalized * speed;
        }else if (this.gameObject.transform.localPosition.x >= 1.8f)
        {
            GetComponent<Rigidbody2D>().velocity = transform.right.normalized * speed*-1;
        }

        // lifeTime秒後に削除
        Destroy(gameObject, lifeTime);
    }
}