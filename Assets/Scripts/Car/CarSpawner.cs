using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] private ObjectPool pool;
    [SerializeField] private Transform spawnPos;
    [SerializeField] private Transform endPos;

    private void Awake()
    {
        pool.CreatePool(OnSpawn);
        foreach (GameObject car in pool.GetPool())
        {
            car.GetComponent<CarMovement>().EndPos = endPos.position;
        }
        StartCoroutine(Spawner());
    }

    private void OnSpawn(GameObject car)
    {
        car.transform.position = spawnPos.position;
    }

    private IEnumerator Spawner()
    {
        pool.SpawnGameObject();
        yield return new WaitForSeconds(Random.Range(2,4));
        StartCoroutine(Spawner());
    }
}
