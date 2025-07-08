using UnityEngine;
using DG.Tweening;
using System;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerMover : MonoBehaviour
{
    [Header("XZ Plane Movements")]
    [SerializeField] float forwardSpeed = 5f;
    [SerializeField] float slideTime = 0.5f;
    [SerializeField] float laneWidth = 2f;

    //---------------------------------------------------------------------------------
    // Zıplama ayarları
    //---------------------------------------------------------------------------------
    [Header("YZ Plane Movements")]
    [SerializeField] float jumpDistance = 4f;
    [SerializeField] float jumpPower = 3f;
    [SerializeField] int numberOfJumps = 1;
    [SerializeField] float duration = 0.5f;
    //---------------------------------------------------------------------------------

    int currentLane = 1;
    private Tween slideTween;
    private Tween jumpTween;
    void Update()
    {

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
            jumper();
        }
    }

    private void jumper()
    {
            jumpTween?.Kill();

            // Hedef pozisyon = şu anki + ileri yönde forwardDistance
            Vector3 endPos = transform.position + transform.forward * jumpDistance;

            // DOJump: (hedef, zıplama yüksekliği, zıplama sayısı, toplam süre)
            jumpTween = transform
                .DOJump(endPos, jumpPower, numberOfJumps, duration)
                .SetEase(Ease.Linear);    }

    void SlideHorizontal(int direction)
    {
        int targetLane = Math.Clamp(direction + currentLane, 0, 2);
        if (targetLane == currentLane) return; // sınırları aşma.

        currentLane = targetLane;
        // Hedef X koordinatını hesapla
        float targetX = laneWidth * (currentLane - 1);

        slideTween?.Kill();
        // Sadece X ekseninde kay
        slideTween = transform.DOMoveX(targetX, slideTime).SetEase(Ease.InOutQuad);
    }

    void FixedUpdate()
    {
        // Sürekli ileri
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
    }
}
