using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View : MonoBehaviour
{
    private MeshRenderer _meshRenderer;
    
    public float animationSpeed = 1f;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        
        Vector2 offset = _meshRenderer.material.mainTextureOffset;

      
        offset.x += animationSpeed * Time.deltaTime;

        
        _meshRenderer.material.mainTextureOffset = offset;
    }
}
