using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Allrotate : MonoBehaviour
{
    public int roop = 1;
    public float roop_delay = 0.5f;
    public GameObject bullet;

    public int rad_interval = 6;
    public int rad_start = 0;
    public int rad_end = 360;

    public float rad_delay = 0.01f;
    public int roop_rad = 2;

    public float start_delay = 0.01f;


    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(start_delay);
        if (rad_delay > 0.000f)
        {
            for (int i = 0; i < roop; i++)
            {
                for (int rad = rad_start; rad <= rad_end; rad += rad_interval)
                {
                    Instantiate(bullet, gameObject.transform.position, Quaternion.Euler(0, 0, (float)rad + i * roop_rad));
                    yield return new WaitForSeconds(rad_delay);
                }
                yield return new WaitForSeconds(roop_delay);
            }
        }
        else
        {
            for (int i = 0; i < roop; i++)
            {
                for (int rad = rad_start; rad <= rad_end; rad += rad_interval)
                {
                    Instantiate(bullet, gameObject.transform.position, Quaternion.Euler(0, 0, (float)rad + i * roop_rad));
                }
                yield return new WaitForSeconds(roop_delay);
            }
        }
    }
}
