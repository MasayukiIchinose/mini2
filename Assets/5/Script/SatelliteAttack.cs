using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatelliteAttack : MonoBehaviour
{
    public GameObject ballets5_1;
    public GetAim ga;
    private float speed;
    private float radius;
    private float yPosition;
    string objectName;
    int objectNumber;

    public void LRAttack()
    { 

        float dx = transform.parent.position.x - transform.position.x;
        float dy = transform.parent.position.y - transform.position.y;
        float rad = Mathf.Atan2(dy, dx);
        
        Quaternion target = Quaternion.Euler(0, 0, rad * Mathf.Rad2Deg + 90 + 180.0f);
        Instantiate(ballets5_1, transform.position, target);
        
    }

    public void SAttack()
    {
        Instantiate(ballets5_1, transform.position, Quaternion.identity);

    }
}
