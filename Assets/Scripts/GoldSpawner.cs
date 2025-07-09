using UnityEngine;

public class GoldSpawner : MonoBehaviour
{
    [Header("Obstacle Prefabs")]
    public GameObject[] obstaclePrefabs; //Spawn edilecek obstacle prefab'ları

    [Header("Spawn Timing")]
    public float timeBetweenSpawn = 1.5f; // İki spawn arasında bekleme süresi
    private float spawnTimer;

    [Header("Spawn Area")]
    public float minX = -1.5f; //X ekseninde minimum
    public float maxX = 1.5f; //X ekseninde maksimum offset
    public float minZ = 5f; //Z ekseninde minimum 
    public float maxZ = 15f; //Z ekseninde maksimum
    public float yOffset = 0.5f; //Y ekseninde yükseklik

    void Start()
    {
        // İlk spawn'u zamanlamak için
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
        // Rastgele prefab seç
        GameObject prefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];

        // X,Z için rastgele koordinat
        float x = Random.Range(minX, maxX);
        float z = Random.Range(minZ, maxZ);

        Vector3 spawnPos = transform.position
                         + new Vector3(x, yOffset, z);

        Instantiate(prefab, spawnPos, prefab.transform.rotation);
    }
}
