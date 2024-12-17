using System;
using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float _timeRange = 2f;
    private float _rangeY;
    private float _leftEdge;

    private void Start()
    {
        _leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x;
    }

    private void Update()
    {
        transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);
        DestroyPipe();
    }

    private void DestroyPipe()
    {
        if (transform.position.x < _leftEdge) Destroy(gameObject);
    }

    private void MovePipe()
    {
        _rangeY = Mathf.PingPong(Time.time * _timeRange, _timeRange) - _timeRange / 2;
        transform.position = new Vector3(transform.position.x, _rangeY, transform.position.z);
    }
}
