using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Bird bird;
	public TMP_Text text123;
    public GameObject startButton;
    public GameObject exitButton;
	public GameObject boom;
    private int score;
    public AudioSource backgroundMusic1; // 第一个背景音乐
    public AudioSource backgroundMusic2; // 第二个背景音乐
    public TMP_Text leaderboardText;
    private List<int> leaderboardScores = new List<int>(); // 用于存储排行榜分数

    public void End()
    {
        Debug.Log("Game End!!");
		Boom();
        RecordScore(); // 记录当前分数
    }

    public void Calculating()
    {
        score++;
        Debug.Log("Score: " + score);
		UpdateScoreText();
    }
    
    public void Awake()
         {
             Application.targetFrameRate = 60;
             Pause(); 
             if (backgroundMusic1 != null)
    {
        backgroundMusic1.Play(); // 播放第一个背景音乐
    }

    if (backgroundMusic2 != null)
    {
        backgroundMusic2.Stop(); // 确保第二个背景音乐不播放
    }
    boom.SetActive(false);
         }

	public void Boom()
    {
        startButton.SetActive(true);
        exitButton.SetActive(true);
        boom.SetActive(true);
        Pause();
        if (backgroundMusic1 != null && backgroundMusic1.isPlaying)
    {
        backgroundMusic1.Stop(); // 停止第一个背景音乐
    }

    if (backgroundMusic2 != null)
    {
        backgroundMusic2.Play(); // 播放第二个背景音乐
    }
    }

    public void game()
    {
		score = 0;
		UpdateScoreText();
        startButton.SetActive(false);
        exitButton.SetActive(false);
		boom.SetActive(false);
        Time.timeScale = 1f;
        bird.enabled = true;
        Trees[] trees = FindObjectsOfType<Trees>();

        for (int i = 0; i < trees.Length; i++) {
            Destroy(trees[i].gameObject);
        }
        if (backgroundMusic1 == null || backgroundMusic2 == null)
    {
        Debug.LogError("The AudioSource for the background music is not assigned!");
    }
    else
    {
        Debug.Log("The AudioSource for the background music is assigned correctly.");
    }

    if (backgroundMusic2 != null && backgroundMusic2.isPlaying)
    {
        backgroundMusic2.Stop(); // 停止第二个背景音乐
    }

    if (backgroundMusic1 != null)
    {
        backgroundMusic1.Play(); // 播放第一个背景音乐
    }
    }
    
    public void Pause()
    {
        Time.timeScale = 0f;
        bird.enabled = false;
        

    }

	private void UpdateScoreText()
    {
        text123.text = score.ToString();
    }

    private void RecordScore()
    {
        leaderboardScores.Add(score); // 添加当前分数到排行榜
        leaderboardScores.Sort((a, b) => b.CompareTo(a)); // 按分数从高到低排序
        UpdateLeaderboardText(); // 更新排行榜显示
    }

    private void UpdateLeaderboardText()
    {
        leaderboardText.text = "Leaderboard:\n";
        for (int i = 0; i < leaderboardScores.Count && i < 5; i++) // 显示前五名
        {
            leaderboardText.text += $"{i + 1}. Score: {leaderboardScores[i]}\n";
        }
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // 示例场景跳转方法，用于从当前场景跳转到特定场景
    public void LoadMain()
    {
        ChangeScene("Main"); // 将 "MainMenu" 替换为你的场景名
    }
    
}
