using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    
    public Sprite[] sprites;
    private int _sprite;
    
    public float strength = 5f;
    public float gravity = -9.8f;
    
    private Vector3 _direction;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    private void Update()
    {
        HandleInput();
        ApplyGravity();
        MoveCharacter();
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            _direction = Vector3.up * strength;
        }
    }

    private void ApplyGravity()
    {
        _direction.y += gravity * Time.deltaTime;
    }

    private void MoveCharacter()
    {
        transform.position += _direction * Time.deltaTime;
    }

    private void AnimateSprite()
    {
        _sprite++;
        if (_sprite >= sprites.Length)
        {
            _sprite = 0;
        }

        if (_sprite >= 0 && _sprite < sprites.Length)
        {
            _spriteRenderer.sprite = sprites[_sprite];
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "Obstacle")
        {
            FindObjectOfType<GameManager>().End();
        }
        else if (other.gameObject.tag == "Scoring")
        {
           
            FindObjectOfType<GameManager>().Calculating();
        }
    }
}
