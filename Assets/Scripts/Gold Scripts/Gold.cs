using UnityEngine;
public class Gold : MonoBehaviour
{
    private ObjectPool pool;

    void Awake()
    {
        pool = GameObject.Find("GoldPool")
                       .GetComponent<ObjectPool>();
        if (pool == null) Debug.LogError("GoldPool bulunamadı!");
    }

    void OnTriggerEnter(Collider other)
    {
        GoldCounterText.goldCounter++;

        pool.ReturnToPool(gameObject);
    }
}
