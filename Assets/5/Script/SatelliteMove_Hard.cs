using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatelliteMove_Hard : MonoBehaviour
{

    public Rigidbody2D rbody;
    private float speed;
    private float radius;
    private float yPosition;
    string objectName;
    int objectNumber;
    float oldSpeed;
    float time;
    bool speedChange;
    bool isSAttack;
    bool isSAttack2;
    bool isSAMove;
    public bool isSAMoved;
    Vector3 newPos;
    public Vector3 pastPosition;
    public Vector3 targetPos;

    // Use this for initialization
    IEnumerator Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        isSAttack2=false;
        isSAMoved = false;
        speed = 3.0f;
        radius = 0.45f;
        time = 0;
        oldSpeed = speed;
        objectName = transform.name;
        objectNumber = int.Parse(objectName.Substring(objectName.Length - 1));
        targetPos = new Vector3(-2.5f + 6.5f / 4.0f * (objectNumber - 1), 1.5f, 0);


        while (true)
        {
            
            yield return new WaitForSeconds(0.5f);
            if (isSAMove == true)
            {
                yield return SAMove();
                isSAMoved = true;
            }
            if (isSAttack == true)
            {
                isSAMoved = false;
                yield return SAttack();
                
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent.GetComponent<Stage5_Boss_Hard>().isSAttack)
        {
            if(isSAttack2)
                transform.position = targetPos;

            return;
        }
            

        transform.localPosition = new Vector2(radius * Mathf.Sin(time * speed + Mathf.PI / 2 * objectNumber), radius * Mathf.Cos(time * speed + Mathf.PI / 2 * objectNumber));
        time += Time.deltaTime;
    }


    public IEnumerator SAMove()
    {
        SetIsSAMove(false);

        pastPosition = transform.localPosition;
        while (Mathf.Abs(transform.position.x - targetPos.x) > 0.001f)
        {
            float distance = Vector3.Distance(transform.position, targetPos);
            transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * 3.0f / distance);
            yield return new WaitForSeconds(0.01f);
        }
    }

    public IEnumerator SAttack()
    {
        SetIsSAttack(false);
        isSAttack2 = true;
        float time = 0;
        while (time < 1.0f)
        {
            transform.GetComponent<SatelliteAttack>().SAttack();
            time += Time.deltaTime;
            yield return new WaitForSeconds(0.1f);
        }
        isSAttack2 = false;

        while (Mathf.Abs(transform.position.x - pastPosition.x) > 0.01f)
        {
            float distance = Vector3.Distance(transform.localPosition, pastPosition);
            transform.localPosition = Vector3.Lerp(transform.localPosition, pastPosition, Time.deltaTime * 2.0f / distance);
            yield return new WaitForSeconds(0.01f);
        }
        Debug.Log("a");

        transform.parent.GetComponent<Stage5_Boss_Hard>().isSAttack = false;
    }

    public void SetIsSAttack(bool isSAttack)
    {
        this.isSAttack = isSAttack;
    }

    public void SetIsSAMove(bool isSAMove)
    {
        this.isSAMove = isSAMove;
    }
}
