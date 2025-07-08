using UnityEngine;
using DG.Tweening;
public class Gold : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Gold'a Çarptı");
            transform.DOKill();
            Destroy(gameObject);
        }
    }
}
