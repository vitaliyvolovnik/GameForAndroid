using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{

    [Header("General")]
    [SerializeField] private Transform _spawnContainer;
    [SerializeField] private int _repeatCount;
    [SerializeField] private int _distanceBetweenFullLine;
    [SerializeField] private int _distanceBetweenRandomLine;

    [Header("Block")]
    [SerializeField] private Block _blockTemplate;
    [SerializeField] private int _blockSpawnChance;

    [Header("Wall")]
    [SerializeField] private Wall _wallTemplate;
    [SerializeField] private int _wallSpawnChance;

    [Header("Bonus")]
    [SerializeField] private Bonus _bonusTemplate;
    [SerializeField] private int _bonusSpawnChance;

    [Header("Finish")]
    [SerializeField] private Finish _FinishTemplate;

    private BlockSpawnPoint[] _blockSpawnPoints;
    private WallSpawnPoint[] _wallSpawnPoints;



    private void Start()
    {
        _blockSpawnPoints = GetComponentsInChildren<BlockSpawnPoint>();
        _wallSpawnPoints = GetComponentsInChildren<WallSpawnPoint>();
        for (int i = 0; i < _repeatCount; i++)
        {


            for (int j = 0; j < _distanceBetweenFullLine; j++)
            {
                MoveSpawner(1);
                GenerateRandomLine(_blockSpawnPoints, _bonusTemplate.gameObject, _bonusSpawnChance);
            }
            MoveSpawner(1);

            GenerateRandomLine(_wallSpawnPoints, _wallTemplate.gameObject, _blockSpawnChance);
            GenerateFullLine(_blockSpawnPoints, _blockTemplate.gameObject);


            for (int j = 0; j < _distanceBetweenRandomLine; j++)
            {
                MoveSpawner(1);
                GenerateRandomLine(_blockSpawnPoints, _bonusTemplate.gameObject,_bonusSpawnChance);
            }
            MoveSpawner(1);

            GenerateRandomLine(_blockSpawnPoints, _blockTemplate.gameObject,_blockSpawnChance);
        }
        MoveSpawner(_distanceBetweenRandomLine);
        GenerateElement(transform.position, _FinishTemplate.gameObject);
    }

    private void GenerateRandomLine(SpawnPoint[] blockSpawnPoints, GameObject gameObject, int spawnChange)
    {
        foreach (SpawnPoint spawnPoint in blockSpawnPoints)
            if (Random.Range(0, 100) < spawnChange)
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





