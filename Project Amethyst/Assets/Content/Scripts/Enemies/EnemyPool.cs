using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Pool;

public class EnemyPool : SingletonMono<EnemyPool>
{

    [Header("Pool Info")]
    [SerializeField] private int _defaultPoolSize;
    [SerializeField] private int _maxPoolSize;

    [Header("Pooled Object Info")]
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private List<Transform> _spawnPoint;

    private IObjectPool<GameObject> _pool;
    private bool _collectionCheck;

    protected override void Awake()
    {
        base.Awake();

        Init();
    }

    private void Init()
    {
        _pool = new ObjectPool<GameObject>(CreateEnemy, Get, Release, Clear, _collectionCheck, _defaultPoolSize, _maxPoolSize);

        for (int i = 0; i < _defaultPoolSize; i++)
        {
            CreateEnemy();
        }
    }

    public GameObject CreateEnemy()
    {
        GameObject enemyClone = Instantiate(_enemyPrefab, _spawnPoint[Random.Range(0, _spawnPoint.Count - 1)].position, _enemyPrefab.transform.rotation);
        return enemyClone;
    }

    public void Get(GameObject pooledObject)
    {
        pooledObject.SetActive(true);
    }

    public void Release(GameObject pooledObject)
    {
        pooledObject.SetActive(false);

        pooledObject.transform.position = _spawnPoint[Random.Range(0, _spawnPoint.Count - 1)].position;
        pooledObject.GetComponent<EnemyAI>().enabled = true;
        pooledObject.GetComponent<BoxCollider>().enabled = true;
        pooledObject.GetComponent<EnemyHealth>().enabled = true;
        pooledObject.GetComponent<NavMeshAgent>().enabled = true;
    }

    private void Clear(GameObject pooledObject)
    {
        Destroy(pooledObject.gameObject);
    }
}