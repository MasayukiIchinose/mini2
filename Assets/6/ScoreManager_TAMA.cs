using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager_TAMA : MonoBehaviour
{
    private float starttime;
    private float scoretime;
    private bool flag = false;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        starttime = Time.time;

    }
    // Update is called once per frame
    void Update()
    {
        if (flag)
        {
            if (Time.time - timer > 1.0f)
            {
                string STAGE_NAME = SceneManager.GetActiveScene().name.Replace("Stage_", "");
                SceneManager.LoadScene("Score_" + STAGE_NAME.Replace("_hard", ""));
            }
        }
    }
    public void setScore()
    {
        scoretime = Time.time - starttime;
        //スコアの登録
        string STAGE_NAME = SceneManager.GetActiveScene().name.Replace("Stage_", "");
        if(scoretime < PlayerPrefs.GetFloat(STAGE_NAME + "_SCORE"))
        {
            PlayerPrefs.SetFloat(STAGE_NAME + "_SCORE", scoretime);
        }
        PlayerPrefs.SetInt(STAGE_NAME + "_CLEAR", PlayerPrefs.GetInt(STAGE_NAME + "_CLEAR") + 1);
                //スコア表示画面に移行（hardの場合文字列からハードを取り除く）  
        SceneManager.LoadScene(("Score_" + STAGE_NAME).Replace("_hard",""));

        Debug.Log("SET "+STAGE_NAME + "_SCORE->" + PlayerPrefs.GetFloat(STAGE_NAME + "_SCORE"));
        Debug.Log("SET "+STAGE_NAME + "_CLEAR->" + PlayerPrefs.GetFloat(STAGE_NAME + "_CLEAR"));
        flag = true;
        timer = Time.time;
    }
    public void backScene()
    {
        flag = true;
        timer = Time.time;
    }
}
