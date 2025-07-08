using UnityEngine;
using DG.Tweening;

public class GoldMovement : MonoBehaviour
{
    void Update()
    {
        transform.DORotate(new Vector3(0, 360, 0), 2f, RotateMode.LocalAxisAdd).SetLoops(-1);
    }
}