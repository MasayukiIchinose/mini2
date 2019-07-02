using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAim
{
    public float getAim(Vector2 p1, Vector2 p2)
    {
        if (GameObject.Find("player") != null)
        {
            float dx = p2.x - p1.x;
            float dy = p2.y - p1.y;
            float rad = Mathf.Atan2(dy, dx);
            return rad * Mathf.Rad2Deg + 90;
        }
        return 0.0f;
    }
    public Quaternion getAimQua(Vector2 p1, Vector2 p2)
    {
        return Quaternion.Euler(0, 0, getAim(p1, p2));
    }
}
