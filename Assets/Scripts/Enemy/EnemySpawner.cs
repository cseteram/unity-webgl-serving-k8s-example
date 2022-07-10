using System;
using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private BoundaryData _boundaryData;
    [SerializeField] private float _spawnPeriod = 0.25f;

    private GameObject _playerGameObject;

    private void Start()
    {
        _playerGameObject = GameObject.FindWithTag("Player");

        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            var spawnPosition = GetSpawnPosition(Random.Range(0, 4));
            var enemy = Instantiate<GameObject>(_enemyPrefab, spawnPosition, Quaternion.identity);
            enemy.GetComponent<EnemyBehaviour>().SetDestination(_playerGameObject.transform.position);
            enemy.transform.SetParent(gameObject.transform);

            yield return new WaitForSeconds(_spawnPeriod);
        }
    }

    private Vector3 GetSpawnPosition(int type)
    {
        var ret = Vector3.zero;

        switch (type)
        {
            case 0:
                ret.x = _boundaryData.xMin;
                ret.y = Random.Range(_boundaryData.yMin, _boundaryData.yMax);
                break;
            case 1:
                ret.x = _boundaryData.xMax;
                ret.y = Random.Range(_boundaryData.yMin, _boundaryData.yMax);
                break;
            case 2:
                ret.x = Random.Range(_boundaryData.xMin, _boundaryData.xMax);
                ret.y = _boundaryData.yMin;
                break;
            case 3:
                ret.x = Random.Range(_boundaryData.xMin, _boundaryData.xMax);
                ret.y = _boundaryData.yMax;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        return ret;
    }
}
