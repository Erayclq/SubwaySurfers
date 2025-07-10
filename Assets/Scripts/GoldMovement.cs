using UnityEngine;
using DG.Tweening;

public class GoldMovement : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(new Vector3(0,120*Time.deltaTime,0), Space.Self);
    }
}