using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class BirdController : MonoBehaviour
{
    

    public float jumpForce = 5f;
    public TextMeshProUGUI gameOverText; // 游戏结束提示文字
    public TextMeshProUGUI scoreText; // 显示分数的文字
    public Button restartButton; // 重新开始按钮
    public Button quitButton; // 退出按钮
    public CoinSpawner coinSpawner; // CoinSpawner 脚本的引用
    public AudioSource backgroundMusic; // 背景音乐的AudioSource组件
    private Rigidbody2D rb;
    private bool isGameOver = false;
    private bool isGameStarted = false; // 游戏是否已经开始的标志
    private Vector3 initialPosition; // 小鸟的初始位置
    private int score = 0; // 记录小鸟获得的分数

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialPosition = transform.position; // 保存小鸟的初始位置
        rb.gravityScale = 0; // 暂停小鸟的重力，让小鸟在游戏开始前不下落

        // 隐藏游戏结束的文字
        gameOverText.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(true);
        scoreText.text = "0";

        // 在游戏开始前显示“重新开始”和“退出”按钮
        restartButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);

        // 为“重新开始”按钮绑定游戏启动事件
        restartButton.onClick.AddListener(StartGame);

        // 为退出按钮绑定退出游戏事件
        quitButton.onClick.AddListener(QuitGame);

        // 确保游戏开始前不生成金币
        coinSpawner.StopSpawning();

        // 确保音乐在游戏开始前不播放
        if (backgroundMusic != null)
        {
            backgroundMusic.Stop();
        }
    }

    void Update()
    {
        if (isGameStarted && !isGameOver && Input.GetMouseButtonDown(0)) // 游戏开始且未结束时，点击鼠标左键让小鸟跳跃
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // 碰到地面
        {
            isGameOver = true;
            Debug.Log("Game Over!");

            gameOverText.gameObject.SetActive(true); // 显示游戏结束的文字
            restartButton.gameObject.SetActive(true); // 显示重新开始按钮
            quitButton.gameObject.SetActive(true); // 显示退出按钮
            Time.timeScale = 0; // 暂停游戏

            // 停止生成金币
            coinSpawner.StopSpawning();

            // 停止背景音乐
            if (backgroundMusic != null)
            {
                backgroundMusic.Stop();
            }
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject); // 销毁金币对象
            score++; // 增加分数
            scoreText.text = score.ToString(); // 更新显示的分数

            if (score >= 10) // 当分数达到10时，结束游戏
            {
                EndGame();
            }
        }
    }

    void EndGame()
    {
        isGameOver = true;
        gameOverText.gameObject.SetActive(true); // 显示游戏结束的文字
        restartButton.gameObject.SetActive(true); // 显示重新开始按钮
        quitButton.gameObject.SetActive(true); // 显示退出按钮
        Time.timeScale = 0; // 暂停游戏

        // 停止生成金币
        coinSpawner.StopSpawning();

        // 停止背景音乐
        if (backgroundMusic != null)
        {
            backgroundMusic.Stop();
        }
    }

    void StartGame()
    {
        isGameStarted = true; // 标志游戏已开始
        rb.gravityScale = 1; // 恢复小鸟的重力
        Time.timeScale = 1; // 恢复游戏时间

        // 重置分数
        score = 0;
        scoreText.text = "0";

        // 隐藏“重新开始”和“退出”按钮
        restartButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(false);

        // 重置小鸟的位置和状态
        transform.position = initialPosition; // 重置小鸟的位置
        rb.velocity = Vector2.zero; // 重置小鸟的速度
        isGameOver = false; // 重置游戏结束标志

        // 开始生成并移动金币
        coinSpawner.StartSpawning();

        // 开始播放背景音乐
        if (backgroundMusic != null)
        {
            backgroundMusic.Play();
        }
    }

    void RestartGame()
    {
        Time.timeScale = 1; // 恢复游戏时间
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // 重新加载当前场景
    }

    void QuitGame()
    {
        Application.Quit(); // 退出游戏（仅适用于构建后的应用程序）
    }
}
