using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaniDanmakuMove : MonoBehaviour
{
    public GameObject kani;
   
    
    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void KaniStart()
    {
        StartCoroutine(KaniWave());
    }
    public IEnumerator KaniWave()
    {
        GetAim ga = new GetAim();
        while (true)
        {
            
            // Debug.Log(stageJudge);
            yield return new WaitForSeconds(1f); 
            Instantiate(kani, gameObject.transform.position, ga.getAimQua(gameObject.transform.position, GameObject.Find("player").transform.position));
            
        }
    }
}
