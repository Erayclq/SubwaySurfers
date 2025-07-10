using UnityEngine;

public class EndlessRoad : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            transform.position += Vector3.forward * 24.97879f * 3f;
        }
    }
}
