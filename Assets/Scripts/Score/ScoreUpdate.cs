using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreUpdate : MonoBehaviour
{

    void Start()
    {
        string STAGE_NAME = SceneManager.GetActiveScene().name.Replace("Score_", "");
        if (!PlayerPrefs.HasKey(STAGE_NAME + "_hard_CLEAR"))
        {
            Debug.Log("新規に "+ STAGE_NAME + " のデータを保存します");
            PlayerPrefs.SetInt(STAGE_NAME + "_CLEAR", 0);
            PlayerPrefs.SetFloat(STAGE_NAME + "_SCORE", 9999.99f);
        }
        if (!PlayerPrefs.HasKey(STAGE_NAME + "_hard_CLEAR"))
        {
            Debug.Log("新規に " + STAGE_NAME + "_hard のデータを保存します");
            PlayerPrefs.SetInt(STAGE_NAME + "_hard_CLEAR", 0);
            PlayerPrefs.SetFloat(STAGE_NAME + "_hard_SCORE", 9999.99f);
        }

        // オブジェクトからTextコンポーネントを取得
        GameObject.Find("Text_EasyClearData").GetComponent<Text>().text = PlayerPrefs.GetInt(STAGE_NAME + "_CLEAR").ToString();
        GameObject.Find("Text_EasyScoreData").GetComponent<Text>().text = PlayerPrefs.GetFloat(STAGE_NAME + "_SCORE").ToString();
        GameObject.Find("Text_HardClearData").GetComponent<Text>().text = PlayerPrefs.GetInt(STAGE_NAME + "_hard_CLEAR").ToString();
        GameObject.Find("Text_HardScoreData").GetComponent<Text>().text = PlayerPrefs.GetFloat(STAGE_NAME + "_hard_SCORE").ToString();
    }
}
