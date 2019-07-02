using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Denger : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(2.0f);
        Destroy(gameObject);
    }
}
