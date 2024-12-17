using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float _bottomEdge;
    private float _topEdge;
    private bool _isAlive = true;
    [SerializeField] private float flappingSpeed = 20f;
    [SerializeField] private GameManager manager;
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _topEdge = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 1f, 0)).y;
        _bottomEdge = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0, 0)).y;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _isAlive)
        {
            _rb.linearVelocity = Vector2.up * flappingSpeed;
        }
        ScreenBoundary();
    }

    private void ScreenBoundary()
    {
        if (transform.position.y > _topEdge || transform.position.y < _bottomEdge) manager.GameOver();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("scoring")) manager.AddScore(1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Obstacle")) return;
        _isAlive = false;
        manager.GameOver();
    }
    
}
