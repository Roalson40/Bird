using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    
   public void ChangeSceneDiffcult()
    {
        Debug.Log("ChangeScene method called"); // 添加调试日志
        SceneManager.LoadScene("Bird");
    }
    public void ChangeSceneEasy()
    {
        Debug.Log("ChangeScene method called"); // 添加调试日志
        SceneManager.LoadScene("Bird1");
    }
}