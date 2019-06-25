using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet1 : MonoBehaviour
{
    int rotateSpeed = -10;
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotateSpeed));
    }
}
