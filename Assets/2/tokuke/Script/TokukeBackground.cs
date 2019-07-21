using UnityEngine;
using System.Collections;

public class TokukeBackground : MonoBehaviour
{
    public float speed;
    private Vector3 startPosition;
    private void Start()
    {
        startPosition = transform.position;
    }
    void Update()
    {
        transform.Translate(speed, 0, 0);
        if (transform.position.x < -6.4f)
        {
            transform.position = new Vector3(6.74f,startPosition.y, startPosition.z);
        }
    }
}