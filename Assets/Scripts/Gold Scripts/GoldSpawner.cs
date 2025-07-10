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
    public float minZ = 5f, maxZ = 15f;
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
        //k oordinatlarında X değeri
        float worldX = Random.Range(minX, maxX);
        // Spawner’ın Z pozisyonuna eklenen Z değeri
        float worldZ = transform.position.z + Random.Range(minZ, maxZ);

        // 3) Spawn pozisyonunu oluştur
        Vector3 spawnPos = new Vector3(worldX, yOffset, worldZ);

        // 4) Havuzdan nesneyi al
        goldPool.getFromPool(spawnPos, Quaternion.identity);
    }

}
