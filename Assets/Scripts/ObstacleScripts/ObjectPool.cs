using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [Header("Prefab & Boyut")]
    [SerializeField] GameObject poolPrefab;
    [SerializeField] int initialPoolSize = 5;

    [Header("Buraya Oluşsunlar")]
    [Tooltip("Yeni objelerin instantiate edileceği parent")]
    [SerializeField] Transform poolContainer;  

    private Queue<GameObject> pool = new Queue<GameObject>();

    void Start()
    {
        // Eğer poolContainer bağlanmadıysa, kendi transform'unu kullan
        if (poolContainer == null) 
            poolContainer = this.transform;

        // Başlangıç havuzunu yarat
        for (int i = 0; i < initialPoolSize; i++)
        {
            // parent olarak poolContainer kullan
            GameObject obj = Instantiate(poolPrefab, poolContainer);
            obj.SetActive(false);
            pool.Enqueue(obj);
        }
    }

    public GameObject getFromPool(Vector3 position, Quaternion rotation)
    {
        // Gerekirse havuzu büyüt
        if (pool.Count == 0)
        {
            GameObject extra = Instantiate(poolPrefab, poolContainer);
            extra.SetActive(false);
            pool.Enqueue(extra);
        }

        // Havuzdan objeyi al, konumla, aktif et
        GameObject instance = pool.Dequeue();
        instance.transform.SetParent(poolContainer, true);
        instance.transform.SetPositionAndRotation(position, rotation);
        instance.SetActive(true);
        return instance;
    }

    public void ReturnToPool(GameObject instance)
    {
        // Pasifleştirip yine aynı container altına koy
        instance.SetActive(false);
        instance.transform.SetParent(poolContainer, true);
        pool.Enqueue(instance);
    }
}
