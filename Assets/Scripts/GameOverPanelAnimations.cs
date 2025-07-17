using UnityEngine;
using DG.Tweening;

public class GameOverPanelAnimations : MonoBehaviour
{
    public GameObject pauseButton;
    public RectTransform goldText;
    public RectTransform goldImage;

    [SerializeField] float duration = 1f;
    public RectTransform backGround;
    public RectTransform GameOverText;
    public RectTransform restartButton;

    Tween bgTween, textTween, btnTween;

    void Start()
    {
        restartButton.gameObject.SetActive(false);
        GameOverText.gameObject.SetActive(false);

        pauseButton.SetActive(false);

        bgTween = backGround.DOScale(Vector3.zero, duration).From().OnComplete(() =>
            {
                restartButton.gameObject.SetActive(true);
                GameOverText.gameObject.SetActive(true);

                textTween = GameOverText.DOScale(Vector3.zero, duration).From();

                btnTween = restartButton.DOScale(Vector3.zero, duration).From();

                goldText.DOAnchorPos3D(new Vector2(81, -674), duration);
                goldImage.DOAnchorPos3D(new Vector2(900, -687), duration);
            });
    }

    void OnDisable()
    {
        bgTween?.Kill();
        textTween?.Kill();
        btnTween?.Kill();
        pauseButton.SetActive(true);
    }
}
