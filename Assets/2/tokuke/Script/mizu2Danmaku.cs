using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mizu2Danmaku : MonoBehaviour
{
    public int speed = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.up.normalized * speed;
        Destroy(gameObject, 10);
    }

    // Update is called once per frame
    
}
