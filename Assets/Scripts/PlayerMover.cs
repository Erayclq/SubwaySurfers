using UnityEngine;
using DG.Tweening;
using System;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] float forwardSpeed = 5f;
    [SerializeField] float slideTime = 0.5f;
    [SerializeField] float laneWidth = 2f;

    //---------------------------------------------------------------------------------
    [SerializeField] float jumpDistance = 3f;
    [SerializeField] float jumpPower;
    [SerializeField] int numberOfJumps = 1;
    [SerializeField] float duration;

    int currentLane = 1;
    private Tween slideTween;

    void FixedUpdate()
    {
        // Sürekli ileri
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);


        if (Input.GetKeyDown(KeyCode.A))
        {
            SlideHorizontal(-1);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            SlideHorizontal(+1);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.DOJump(new Vector3(transform.position.x,(transform.position.z)), jumpPower, numberOfJumps, duration);
        }
    }

    void SlideHorizontal(int direction)
    {
        int targetLane = Math.Clamp(direction + currentLane, 0,2);
        if (targetLane == currentLane) return; // sınırları aşma.

        currentLane = targetLane;
        // Hedef X koordinatını hesapla
        float targetX = laneWidth*(currentLane-1);

        // Sadece X ekseninde kay
        slideTween = transform.DOMoveX(targetX, slideTime).SetEase(Ease.InOutQuad);
    }
}
