using UnityEngine;
using DG.Tweening;
using System;

public class PlayerMover : MonoBehaviour
{
    Animator playerAnim;
    //---------------------------------------------------------------------------------
    // İleri Gitme ayarları
    //---------------------------------------------------------------------------------
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
    private int currentLane = 1;
    private Tween slideTween;
    private Tween jumpTween;
    //---------------------------------------------------------------------------------
    void Start()
    {
        playerAnim = transform.GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            playerAnim.SetTrigger("RunRight");
            SlideHorizontal(-1);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            playerAnim.SetTrigger("RunLeft");
            SlideHorizontal(+1);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerAnim.SetTrigger("Jump_Up");
            jumper();
        }
    }
    void FixedUpdate()// Ileri harket.
    {
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
    }
    private void jumper()//Zıplamayı sağlar
    {
        if (transform.position.y == 0) // sadece yerdeyken zıplayabilir player
        {
            jumpTween?.Kill();
            // Hedef pozisyon = şu anki + ileri yönde forwardDistance
            Vector3 endPos = transform.position + transform.forward * jumpDistance;

            jumpTween = transform.DOJump(endPos, jumpPower, numberOfJumps, duration).SetEase(Ease.Linear);
        }
    }
    void SlideHorizontal(int direction)//Sağ ve Sola gitme
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

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            playerAnim.SetBool("WallCrash", true);
        }
    }

}
