using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround_TAMA1 : MonoBehaviour
{

    public GameObject loop1Obj;
    public GameObject loop2Obj;
    private float startPos;
    private float startPosLoop1Obj;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.y;
        startPosLoop1Obj = loop1Obj.transform.position.y;
        //Debug.Log(startPos);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0,-0.02f,0));

        if (startPosLoop1Obj - 0.01f <= loop2Obj.transform.position.y &  loop2Obj.transform.position.y <= startPosLoop1Obj + 0.01f )
        {
            Vector3 tmpPos = transform.position;

            tmpPos.y = startPos;

            transform.position = tmpPos;
        }

    }
}
