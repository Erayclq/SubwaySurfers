    using UnityEngine;

public class GoldSpawner : MonoBehaviour
{
    [Header("Pool Referansı")]
    public ObjectPool goldPool;           // Inspector’da GoldPool objesini ata

    [Header("Spawn Timing")]
    public float timeBetweenSpawn = 1.5f;
    private float spawnTimer;

    [Header("Spawn Area")]
    public float minX = -1.5f, maxX = 1.5f;
    public float minZ = 5f,     maxZ = 15f;
    public float yOffset = 0.5f;

    void Start()
    {
        spawnTimer = timeBetweenSpawn;
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0f)
        {
            SpawnGold();
            spawnTimer = timeBetweenSpawn;
        }
    }

    void SpawnGold()
    {
        // Rastgele pozisyon
        float x = Random.Range(minX, maxX);
        float z = Random.Range(minZ, maxZ);
        Vector3 spawnPos = transform.position + new Vector3(x, yOffset, z);

        // Instantiate yerine pool’dan aldı....
        goldPool.getFromPool(spawnPos, Quaternion.identity);
    }
}
