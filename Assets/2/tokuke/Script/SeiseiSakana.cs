using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeiseiSakana : MonoBehaviour
{
    public GameObject sakana;
    public float rand;
    
    IEnumerator Start()
    {
       
        while (true)
        {
            rand = Random.Range(5.0f, 20.0f);
            yield return new WaitForSeconds(rand);
            Instantiate(sakana, gameObject.transform.position, Quaternion.identity);
            
        }
    }
    }
