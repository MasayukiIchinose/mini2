using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaniWalk : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 0.2f;
    public float waitTime=0.5f;
    private Animator _animator;
    private float animSpeed=0.14f;
    public float judge = -1.0f;
    void Start()
    {
     
        this._animator = this.gameObject.GetComponent<Animator>();
        this._animator.speed = animSpeed;
        _animator.PlayInFixedTime(0);
        StartCoroutine(Walk());
        
    }

    // Update is called once per frame
    private IEnumerator Walk()
    {
        
        while (true)
        {
            if (this.gameObject.transform.localPosition.x >= 1.80)
            {
                judge = -1.0f;
            }
            else if (this.gameObject.transform.localPosition.x <= -4.9)
            {
                judge = 1.0f;
            }
            
            transform.Translate(speed*judge, 0, 0);
            yield return new WaitForSeconds(0.6f);
        }
    }
}
