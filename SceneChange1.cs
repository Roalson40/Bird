using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange1 : MonoBehaviour
{
    public void ChangeScene1()
    {
        Debug.Log("ChangeScene1 method called"); // 添加调试日志
        SceneManager.LoadScene("Main");
    }
}
