using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiffManager : MonoBehaviour
{
    public TMP_Dropdown dropdown;  // 引用 Dropdown 组件

    void Start()
    {
        // 确保下拉菜单初始设置正确
        dropdown.onValueChanged.AddListener(delegate { ChangeDifficulty(dropdown.value); });
    }

    void ChangeDifficulty(int index)
    {
        switch (index)
        {
            case 0:
                Debug.Log("难度设置为简单");
                // 设置游戏为简单难度的代码
                break;
            case 1:
                Debug.Log("难度设置为困难");
                // 设置游戏为困难难度的代码
                break;
            default:
                Debug.Log("未知难度");
                break;
        }
    }
}
