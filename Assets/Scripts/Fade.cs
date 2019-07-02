using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    public GameObject fade = null;
    public bool start_fade = false;
    public float fade_time = 0.5f;
    // Start is called before the first frame update

    void Start()
    {
        if (start_fade) {
            fadein(fade_time);
        }
    }
    public void fadein(float time)
    {
        GameObject fad = Instantiate(fade, new Vector3(0.0f, 0.0f, -7.0f), Quaternion.identity);
        Rigidbody2D rb = fad.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(1,0)*(12/time);
    }
    public void fadein()
    {
        fadein(fade_time);
    }
    public void fadeout(float time)
    {
        GameObject fad = Instantiate(fade, new Vector3(6.0f, 0.0f, -7.0f), Quaternion.identity);
        Rigidbody2D rb = fad.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(1, 0) * (12 / time);
    }
    public void fadeout()
    {
        fadeout(fade_time);
    }
}