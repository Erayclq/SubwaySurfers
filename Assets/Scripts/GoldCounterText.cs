using UnityEngine;
using TMPro;
public class GoldCounterText : MonoBehaviour
{
    public static int goldCounter = 0;
    [SerializeField] private TextMeshProUGUI goldText;
    void Update()
    {
        goldText.text = goldCounter.ToString(); // Integer'ı stringe çevirdik
    }
}
