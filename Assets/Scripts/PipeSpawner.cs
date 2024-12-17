using System;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject pipePrefab;
    private const float TimeToSpawn = 2.5f;
    private float _time;
    private float _range = 5f;
    private float _rangeY;
    private float _newY;
    

    private void Start()
    {
        SpawnPipe();
    }

    private void Update()
    {
        if (_time < TimeToSpawn)
        {
            _time += Time.deltaTime;
        }
        else
        {
            SpawnPipe();
            _time = 0f;
        }
    }
    

    private void SpawnPipe()
    {
        _rangeY = UnityEngine.Random.Range(-_range, _range);
        transform.position = new Vector3(transform.position.x, _rangeY, transform.position.z);
        Instantiate(pipePrefab, transform.position, Quaternion.identity);
    }
}
