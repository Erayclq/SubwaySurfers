using UnityEngine;

public class ObstacleKiller : MonoBehaviour
{

    Vector3 currPosition;
    [SerializeField] private Transform player;
    [SerializeField] private float destroyBehind = 2f; // Ne kadar arkasında kalırsa silinsin ?
    void Start()
    {
        currPosition = transform.position; 
    }

    void Update()
    {
        if ( transform.position.z < player.position.z - destroyBehind)
        {
            Destroy(gameObject);
        }
    }
}
