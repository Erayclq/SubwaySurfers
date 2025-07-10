using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    [Header("Havuz Listesi")]
    public ObjectPool[] obstaclePools;

    [Header("Spawn Zamanlamasi")]
    public float timeBetweenSpawn = 2f;
    private float spawnTimer;

    [Header("Alan Ayarları")]
    public float minX = -1.5f, maxX = 1.5f;
    public float minZ = 5f, maxZ = 15f;
    public float yOffset = 0f;

    void Start()
    {
        spawnTimer = timeBetweenSpawn;
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0f)
        {
            SpawnObstacle();
            spawnTimer = timeBetweenSpawn;
        }
    }

    void SpawnObstacle()
    {
        // Havuzlardan rastgele birini seç
        int obsrcl = Random.Range(0, obstaclePools.Length);
        ObjectPool chosenPool = obstaclePools[obsrcl];

        // World koordinatlarında X ve Z değerlerini hesapla
        float worldX = Random.Range(minX, maxX);
        float worldZ = transform.position.z + Random.Range(minZ, maxZ);

        // Spawn pozisyonunu oluştur
        Vector3 spawnPos = new Vector3(worldX, 0f, worldZ);

        // Seçilen havuzdan al
        chosenPool.getFromPool(spawnPos, Quaternion.identity);
    }

}
