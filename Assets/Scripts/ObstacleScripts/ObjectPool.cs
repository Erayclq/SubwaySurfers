using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject poolPrefab;
    [SerializeField] int initialPoolSize = 5;

    private Queue<GameObject> pool = new Queue<GameObject>();
    void Start()
    {
        for (int i = 0; i < initialPoolSize; i++)
        {
            GameObject obj = Instantiate(poolPrefab);
            obj.SetActive(false);
            pool.Enqueue(obj);
        }
    }
    public GameObject getFromPool(Vector3 position, Quaternion rotation)
    {
        if (pool.Count == 0)
        {
            GameObject extra = Instantiate(poolPrefab);
            extra.SetActive(false);
            pool.Enqueue(extra);
        }

        GameObject instance = pool.Dequeue();
        instance.transform.SetPositionAndRotation(position, rotation);
        instance.SetActive(true);
        return instance;
    }
    public void ReturnToPool(GameObject instance)
    {
        instance.SetActive(false);
        pool.Enqueue(instance);
    }
}
