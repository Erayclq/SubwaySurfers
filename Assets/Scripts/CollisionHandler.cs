using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    Renderer rend;

    void Start()
    {
        rend = gameObject.GetComponent<Renderer>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            rend.material.color = Color.red;
        }
    } 
}