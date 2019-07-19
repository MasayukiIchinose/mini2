using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage5_Boss_Hard : MonoBehaviour
{
    float baseDir = 0;


    public int hp = 1000;
    //public GameObject enemy1;
    public GameObject ballets5_1;

    private HPBarController hpbc;

    Rigidbody2D rbody;
    private float speed;
    private float radius;
    private float yPosition;
    string objectName;
    int objectNumber;
    float posY;
    float rad;
    GetAim ga = new GetAim();
    float time = 0;

    public bool isFuncBool = false;
    public bool isLRAttack = false;
    public bool isSAttack = false;
    bool SAttackFlag = false;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(0.5f);
        hpbc = GameObject.Find("HPController").GetComponent<HPBarController>();
        rbody = GetComponent<Rigidbody2D>();
        speed = 1.0f;
        radius = 1f;
        posY = transform.position.y;

        while (true)
        {
            yield return new WaitForSeconds(0.01f);


            if (isLRAttack)
                continue;


            if (hpbc.rehp() <= 900)
                baseDir = Random.Range(0, 4);
            //Ai1

            if (baseDir < 2)
                yield return BaseBullet();

            if (isSAttack)
                continue;

            if (baseDir == 2 && !SAttackFlag)
            {
                SAttackFlag = true;
                yield return StltAttack();
            }
            else
            {
                yield return BaseBullet();
            }


            if (baseDir == 3)
            {
                yield return LrotAttack();
                SAttackFlag = false;
            }

        }
    }

    IEnumerator BaseBullet()
    {
        if (GameObject.Find("player") == null)
            yield break;

        Quaternion target = ga.getAimQua(gameObject.transform.position, GameObject.Find("player").transform.position);
        for (int i = 0; i < 3; i++)
        {
            Instantiate(ballets5_1, gameObject.transform.position, target);
            yield return new WaitForSeconds(0.2f);
        }
        yield return new WaitForSeconds(0.3f);
    }

    public IEnumerator StltAttack()
    {
        yield return new WaitForSeconds(0.01f);
        isSAttack = true;
        foreach (Transform child in this.transform)
        {
            if (null != child.GetComponent<SatelliteMove_Hard>())
            {
                child.GetComponent<SatelliteMove_Hard>().SetIsSAMove(true);
            }
        }

        
        while (true)
        {
            yield return new WaitForSeconds(0.01f);
            A:
            foreach (Transform child in this.transform)
            {
                yield return new WaitForSeconds(0.01f);
                if (null != child.GetComponent<SatelliteMove_Hard>())
                    if (!child.GetComponent<SatelliteMove_Hard>().isSAMoved)
                        goto A;
            }
            break;
        }

        foreach (Transform child in this.transform)
        {
            if (null != child.GetComponent<SatelliteMove_Hard>())
            {
                child.GetComponent<SatelliteMove_Hard>().SetIsSAttack(true);
            }
        }
    }


    public IEnumerator LrotAttack()
    {

        isLRAttack = true;

        Vector3 pastPosition = transform.position;

        while (transform.position != new Vector3(0, 0, 0))
        {
            float distance= Vector3.Distance(transform.position, new Vector3(0, 0, 0));
            transform.position = Vector3.Lerp(transform.position, new Vector3(0, 0, 0), Time.deltaTime * 2.0f / distance);
            yield return new WaitForSeconds(0.01f);
        }


        yield return LRAttack();

        while (transform.position != pastPosition)
        {
            float distance = Vector3.Distance(pastPosition, transform.position);
            transform.position = Vector3.Lerp(transform.position, pastPosition, Time.deltaTime * 2.0f / distance);
            yield return new WaitForSeconds(0.01f);
        }
        isLRAttack = false;
    }

    public IEnumerator LRAttack()
    {

        float time = 0;
        while (time < 1.5f)
        {
            foreach (Transform child in this.transform)
            {
                if (null != child.GetComponent<SatelliteAttack>())
                {
                    child.GetComponent<SatelliteAttack>().LRAttack();
                }
            }
            time += Time.deltaTime;
            yield return new WaitForSeconds(0.05f);
        }

    }

    private void Update()
    {

        if (!isLRAttack)
        {
            posY = transform.position.y;
            transform.position = new Vector2(radius * Mathf.Sin(time * speed), posY);
            time += Time.deltaTime;
        }
    }
}

