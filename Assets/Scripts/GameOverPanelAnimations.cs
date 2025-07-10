using UnityEngine;
using DG.Tweening;
public class GameOverPanelAnimations : MonoBehaviour
{
    [Header("Duration")]
    [SerializeField] float duration = 1f;

    [Header("UI Objects")]
    public RectTransform backGround;
    public RectTransform GameOverText;
    public RectTransform restartButton;
    
    void Start()
    {
        restartButton.gameObject.SetActive(false);
        GameOverText.gameObject.SetActive(false);

        backGround.DOScale(Vector3.zero, duration).From().OnComplete(() =>
        {
            restartButton.gameObject.SetActive(true);
            GameOverText.gameObject.SetActive(true);

            restartButton.DOScale(Vector3.zero, duration).From();
            GameOverText.DOScale(Vector3.zero, duration).From();
        });
    }
}
