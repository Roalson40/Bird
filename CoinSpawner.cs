using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab; // 金币预制体
    public float spawnRate = 2f; // 生成金币的间隔时间
    public float spawnHeight = 2f; // 金币生成的高度范围

    private bool isSpawning = false;

    void Start()
    {
        // 初始状态不生成金币
        isSpawning = false;
    }

    public void StartSpawning()
    {
        isSpawning = true;
        InvokeRepeating("SpawnCoin", 0f, spawnRate);
    }

    public void StopSpawning()
    {
        isSpawning = false;
        CancelInvoke("SpawnCoin");
    }

    void SpawnCoin()
{
    if (!isSpawning) return;

    float randomHeight = Random.Range(-spawnHeight, spawnHeight);
    Vector3 spawnPosition = new Vector3(transform.position.x, randomHeight, 0);
    GameObject newCoin = Instantiate(coinPrefab, spawnPosition, Quaternion.identity);

    CoinMover coinMover = newCoin.GetComponent<CoinMover>();
    if (coinMover != null)
    {
        coinMover.StartMoving();
        Debug.Log("Coin started moving.");
    }
    else
    {
        Debug.LogError("CoinMover component is missing on the coin prefab!");
    }
}
}
