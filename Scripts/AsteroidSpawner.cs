using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _asteroidPrefab = new GameObject[6];

    private Vector2 _secondsBetweenSpawnMinMax = new Vector2(0.5f, 10f);
    private Vector2 _spawnSizleMinMax = new Vector2(1f,1.5f);
    private float _nextSpawnTime;
    private Vector2 _screenHalfSizeWorldUnits;


    void Start()
    {
        _screenHalfSizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > _nextSpawnTime)
        {
            AsteroidSpawn();
        }
    }
    private void AsteroidSpawn()
    {
        float secondsBetweenSpawn = Mathf.Lerp(_secondsBetweenSpawnMinMax.y, _secondsBetweenSpawnMinMax.x, Difficult.GetDifficultyPercent());
        _nextSpawnTime = Time.time + secondsBetweenSpawn;

        float spawnSize = Random.Range(_spawnSizleMinMax.x, _spawnSizleMinMax.y);
        Vector2 spawnPositionTop = new Vector2(Random.Range(-_screenHalfSizeWorldUnits.x, _screenHalfSizeWorldUnits.x), _screenHalfSizeWorldUnits.y + spawnSize);
        Vector2 spawnPositionDown = new Vector2(Random.Range(-_screenHalfSizeWorldUnits.x, _screenHalfSizeWorldUnits.x), -_screenHalfSizeWorldUnits.y - spawnSize);
        Vector2 spawnPositionLeft = new Vector2(-_screenHalfSizeWorldUnits.x - spawnSize, Random.Range(-_screenHalfSizeWorldUnits.y, _screenHalfSizeWorldUnits.y) );
        Vector2 spawnPositionRight = new Vector2(_screenHalfSizeWorldUnits.x + spawnSize, Random.Range(-_screenHalfSizeWorldUnits.y, _screenHalfSizeWorldUnits.y));

        Vector2 spawnSide = SpawnSide(spawnPositionTop, spawnPositionDown, spawnPositionLeft, spawnPositionRight);

        GameObject newAsteroid = (GameObject)Instantiate(_asteroidPrefab[Random.Range(0, 6)], spawnSide, Quaternion.Euler(Vector3.forward));
        newAsteroid.transform.localScale = Vector2.one * spawnSize;
    }
    private Vector2 SpawnSide(Vector2 Top, Vector2 Down, Vector2 Left, Vector2 Right)
    {
        Vector2 vector = new Vector2(); 
        switch (Random.Range(0, 4))
        {
            case 0:
                vector = Top;
                break;
            case 1:
                vector = Down;
                break;
            case 2:
                vector = Left;
                break;
            case 3:
                vector = Right;
                break;
        }
        return vector;
    }

}
