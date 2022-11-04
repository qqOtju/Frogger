using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class ObjectPool
{
    [SerializeField] private GameObject objectPrefab;
    [SerializeField] private Transform container;
    [SerializeField] private int poolCount;
    [SerializeField] private bool autoExpand = true;
    
    private Action<GameObject> _onSpawnFunc;
    private PoolMono _pool;
    public void SpawnGameObject()
    {
        GameObject go = _pool.GetFreeElement();
        _onSpawnFunc(go);
    }

    public List<GameObject> GetPool()
    {
        return _pool.Pool;
    }

    public void CreatePool(Action<GameObject> createFunc)
    {
        _onSpawnFunc = createFunc;
        _pool = new PoolMono(objectPrefab, poolCount, container)
        {
            autoExpand = autoExpand
        };
    }
}
