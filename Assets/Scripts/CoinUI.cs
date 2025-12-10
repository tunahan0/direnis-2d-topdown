using UnityEngine;
using TMPro;

public class CoinUI : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    CoinManager coinManager;

    void Start()
    {
        coinManager = CoinManager.Instance;

        // Sahne açýldýðýnda CoinManager'daki referansý güncelle
        coinManager.coinText = coinText;
        coinManager.UpdateCoinUI();
    }
}
