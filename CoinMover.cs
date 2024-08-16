using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMover : MonoBehaviour
{
    public float moveSpeed = 2f;
    private bool isMoving = false;

    void Update()
    {
        if (isMoving)
        {
            // 将金币向左移动
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

            // 如果金币移动到屏幕外，销毁它
            if (transform.position.x < -10f)
            {
                Destroy(gameObject);
            }
        }
    }

    public void StartMoving()
    {
        isMoving = true;
    }

    public void StopMoving()
    {
        isMoving = false;
    }
}
