using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class ObjectPool
{
    private Action<GameObject> _onSpawnFunc;
    private PoolMono _pool;
    
    [SerializeField] private GameObject objectPrefab;
    [SerializeField] private Transform container;
    [SerializeField] private int poolCount;
    [SerializeField] private bool autoExpand = true;
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
