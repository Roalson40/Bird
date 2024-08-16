using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trees : MonoBehaviour
{

    public float speed = 5f;

    private float leftBoundary;

    private void Start()
    {
        leftBoundary = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.transform.position.z)).x - 1f;
    }

    private void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        
        if (transform.position.x < leftBoundary)
        {
            Destroy(gameObject);
        }
    }
}
