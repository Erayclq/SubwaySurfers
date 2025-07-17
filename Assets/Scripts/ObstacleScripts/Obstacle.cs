using System.Collections;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Border")
        {
            gameObject.SetActive(false);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
                                            //   collision.gameObject.SetActive(false);
         StartCoroutine(PlayerDisable(collision.gameObject));
    }
    IEnumerator PlayerDisable(GameObject player)
    {
        yield return new WaitForSeconds(1.3f);
            player.gameObject.SetActive(false);
    }

}
