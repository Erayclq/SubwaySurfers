using UnityEngine;
public class RotationObstacle : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 120 * Time.deltaTime), Space.Self);
    }
}
