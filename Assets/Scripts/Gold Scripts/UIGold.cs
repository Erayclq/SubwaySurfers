using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIGold : MonoBehaviour
{
    private ObjectPool pool;

    [Header("Flying-Coin UI")]
    public Canvas uiCanvas;                 // Sahnenizdeki Canvas
    public RectTransform coinIcon;          // Sol üstteki icon’un RectTransform’u
    public Image coinUIPrefab;              // Uçan coin için UI Image prefab’ı
    public float flyDuration = 0.6f;        // Animasyon süresi

    void Awake()
    {
        pool = GameObject.Find("GoldPool").GetComponent<ObjectPool>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        // UI coin’i oluştur
        Image uiCoin = Instantiate(coinUIPrefab, uiCanvas.transform);
        RectTransform uiRt = uiCoin.rectTransform;

        // Dünya konumunu Canvas içi koordinata çevir
        Vector2 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            uiCanvas.transform as RectTransform,
            screenPos,
            uiCanvas.worldCamera,
            out Vector2 canvasPos
        );
        uiRt.anchoredPosition = canvasPos;

        // Tween: UI coin’i sol üstteki icon’a doğru gönder
        uiRt
          .DOAnchorPos(coinIcon.anchoredPosition, flyDuration)
          .SetEase(Ease.InQuad)
          .OnComplete(() => {
              // 4) Sayacı artır
              GoldCounterText.goldCounter++;
              Destroy(uiCoin.gameObject);
          });

        // Dünya altın objesini havuza geri koy
        pool.ReturnToPool(gameObject);
    }
}
