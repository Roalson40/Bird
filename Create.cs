using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create : MonoBehaviour
{
    public GameObject obstacles;
    public float createRate = 1f;
    public float minHeight = -1f;
    public float maxHeight = 1f;

    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), createRate, createRate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        GameObject trees = Instantiate(obstacles, transform.position, Quaternion.identity);
        trees.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }
}
