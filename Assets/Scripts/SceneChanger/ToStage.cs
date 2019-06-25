using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToStage : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnClick()
    {
        Debug.Log("Stage_"+(SceneManager.GetActiveScene().name + gameObject.name).Replace("Score_", "").Replace("Play", "").Replace("_easy", ""));
        SceneManager.LoadScene("Stage_" + (SceneManager.GetActiveScene().name + gameObject.name).Replace("Score_", "").Replace("Play", "").Replace("_easy", ""));
    }
}
