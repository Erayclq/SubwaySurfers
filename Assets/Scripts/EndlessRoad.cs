using UnityEngine;

public class EndlessRoad : MonoBehaviour
{
    Transform roadSegment;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            // transform.DOMove(new Vector3(0, 0.05f, 24.97879f * 2f), 0.2f);
            //transform.position += new Vector3(0, 0.05f, 24.82975f);
            //roadSegment.GetComponent<Renderer>().bounds.size.z * 3f


            transform.position += Vector3.forward * 24.82975f * 3f;
        }
    }
}
