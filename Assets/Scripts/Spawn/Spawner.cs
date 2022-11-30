using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnContainer;
    [SerializeField] private int _repeatCount;
    [SerializeField] private int _distanceBetweenFullLine;
    [SerializeField] private int _distanceBetweenRandomLine;

    [SerializeField] private Block _blockTemplate;
    [SerializeField] private int _blockSpawnChance;

    private SpawnPoint[] _blockSpawnPoints;

    private void Start()
    {
        _blockSpawnPoints = GetComponentsInChildren<SpawnPoint>();
        for (int i = 0; i < _repeatCount; i++)
        {
            MoveSpawner(_distanceBetweenFullLine);
            GenerateFullLine(_blockSpawnPoints, _blockTemplate.gameObject);

            MoveSpawner(_distanceBetweenRandomLine);
            GenerateRandomLine(_blockSpawnPoints, _blockTemplate.gameObject);
        }
    }

    private void GenerateRandomLine(SpawnPoint[] blockSpawnPoints, GameObject gameObject)
    {
        foreach (SpawnPoint spawnPoint in blockSpawnPoints)
            if (Random.Range(0, 100) < _blockSpawnChance)
                GenerateElement(spawnPoint.transform.position, gameObject);
    }

    private void GenerateFullLine(SpawnPoint[] blockSpawnPoints, GameObject gameObject)
    {
        foreach(SpawnPoint spawnPoint in blockSpawnPoints)
            GenerateElement(spawnPoint.transform.position, gameObject);
    }

    private GameObject GenerateElement(Vector3 spawnPoint, GameObject gameObject) => Instantiate(gameObject, spawnPoint, Quaternion.identity);

    private void MoveSpawner(int distanceBetweenFullLine)=> transform.position = new Vector3(transform.position.x, transform.position.y + distanceBetweenFullLine, transform.position.z);

}
