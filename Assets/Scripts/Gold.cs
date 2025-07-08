using UnityEngine;
using DG.Tweening;
public class Gold : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Gold Toplandi.");
            GoldCounterText.goldCounter++;
            transform.DOKill();
            Destroy(gameObject);
        }
    }
}
