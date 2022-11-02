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
        List<GameObject> cars = pool.GetPool();
        foreach (GameObject car in cars)
        {
            car.GetComponent<CarMovement>().EndPos = endPos.position;
        }
        StartCoroutine(Spawner());
    }

    private void OnSpawn(GameObject car)
    {
        car.SetActive(false);
        car.transform.position = spawnPos.position;
        car.SetActive(true);
    }

    private IEnumerator Spawner()
    {
        pool.SpawnGameObject();
        yield return new WaitForSeconds(Random.Range(2,6));
        StartCoroutine(Spawner());
    }
}
