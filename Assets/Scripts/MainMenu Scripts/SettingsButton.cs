using DG.Tweening;
using UnityEngine;

public class SettingsButton : MonoBehaviour
{
    [Header("Duration")]
    [SerializeField] float duration = 1f;

    public RectTransform backButton;
    void Start()
    {
        backButton.DOScale(Vector3.zero,duration).From();
    }
}
