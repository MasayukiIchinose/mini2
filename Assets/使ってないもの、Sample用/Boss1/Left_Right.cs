using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Left_Right : MonoBehaviour
{
    public GameObject bullets1_1;
    public GameObject bullets1_2;
    public int roop=2;
    public float rush_delay = 0.5f;
    public float roop_delay = 0.5f;
    public float start_delay = 0.01f;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        int rand = Random.Range(0, 2);
        if (rand == 0) {
            for (int i = 0; i < roop; i++)
            {
                Instantiate(bullets1_2, gameObject.transform.position, Quaternion.identity);
                yield return new WaitForSeconds(roop_delay);
                Instantiate(bullets1_1, gameObject.transform.position, Quaternion.identity);
                yield return new WaitForSeconds(rush_delay);
            }
        }
        else
        {
            for (int i = 0; i < roop; i++)
            {
                Instantiate(bullets1_1, gameObject.transform.position, Quaternion.identity);
                yield return new WaitForSeconds(rush_delay);
                Instantiate(bullets1_2, gameObject.transform.position, Quaternion.identity);
                yield return new WaitForSeconds(roop_delay);
            }
        }
        yield return new WaitForSeconds(start_delay);
        
        

    }
    
}
