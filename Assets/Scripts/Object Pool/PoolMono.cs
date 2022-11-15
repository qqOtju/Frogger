using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class PoolMono
{
    public List<GameObject> Pool { get; private set; }
    
    private readonly Transform _container;
    private readonly GameObject _prefab;

    public bool autoExpand;
    public PoolMono(GameObject prefab, int count, Transform container)
    {
        _prefab = prefab;
        _container = container;
        CreatePool(count);
    }

    private void CreatePool(int count)
    {
        Pool = new List<GameObject>();
        for (int i = 0; i < count; i++)
            CreateObject();
    }

    private GameObject CreateObject(bool isActiveByDefault = false)
    {
        var createdObject = Object.Instantiate(_prefab, _container);
        createdObject.gameObject.SetActive(isActiveByDefault);
        Pool.Add(createdObject);
        return createdObject;
    }

    private bool HasFreeElement(out GameObject element)
    {
        foreach (var mono in Pool)
            if (!mono.gameObject.activeInHierarchy)
            {
                element = mono;
                mono.gameObject.SetActive(true);
                return true;
            }

        element = null;
        return false;
    }

    public GameObject GetFreeElement()
    {
        if (HasFreeElement(out GameObject element))
            return element;
        if (autoExpand)
            return CreateObject(true);
        throw new Exception("No free element in the pool");
    }
}