using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject bullet;
    public int rad_range = 40;
    public int rad_interval = 5;
    IEnumerator Start()
    {
        float baseDir = GetAim(gameObject.transform.position, GameObject.Find("player").transform.position);
        yield return new WaitForSeconds(0.01f);
        for (int rad = rad_range/2*(-1); rad <= rad_range/2; rad += rad_interval)
        {
            Instantiate(bullet, gameObject.transform.position, Quaternion.Euler(0, 0,baseDir - 90+rad));
        }
        yield return new WaitForSeconds(0.5f);
        for (int rad = rad_range / 2 * (-1) + 360; rad >= rad_range/2; rad -= rad_interval)
        {
            Instantiate(bullet, gameObject.transform.position, Quaternion.Euler(0, 0, baseDir - 90 + rad));
        }
    }

    public float GetAim(Vector2 p1, Vector2 p2)
    {
        float dx = p2.x - p1.x;
        float dy = p2.y - p1.y;
        float rad = Mathf.Atan2(dy, dx);
        return rad * Mathf.Rad2Deg;
    }
}
