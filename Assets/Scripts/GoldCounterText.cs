using UnityEngine;
using TMPro;
public class GoldCounterText : MonoBehaviour
{
    public static int goldCounter = 0;
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private TextMeshProUGUI goldTextEndGame;

    void Update()
    {
        goldText.text = goldCounter.ToString(); // Integer'ı stringe çevirdik
        goldTextEndGame.text = goldCounter.ToString();
    }
}
