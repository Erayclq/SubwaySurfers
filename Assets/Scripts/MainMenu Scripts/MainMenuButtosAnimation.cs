using UnityEngine;
using DG.Tweening;
public class MainMenuButtosAnimation : MonoBehaviour
{
    [Header("Duration")]
    [SerializeField] float duration = 1f;

    [Header("Game Name")]
    public RectTransform gameName;

    [Header("UI Buttons")]
    public RectTransform playButton;
    public RectTransform settingsButton;
    public RectTransform quitButton;
    
    void Start()
    {
        gameName.DOAnchorPosY(328,duration);
        playButton.DOScale(Vector3.zero,duration).From();
        settingsButton.DOScale(Vector3.zero,duration).From();
        quitButton.DOScale(Vector3.zero,duration).From();
    }
}
