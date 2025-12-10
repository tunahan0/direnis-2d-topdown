using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance; // Singleton

    public TextMeshProUGUI coinText;
    public int coinCount = 0;

    private void Awake()
    {
        // Singleton kontrolü: birden fazla varsa yenisini sil
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Sahne geçiþinde yok olmasýn
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        coinCount = levelGecis.savedcoinCount;
        UpdateCoinUI();
    }

    public void AddCoin(int amount)
    {
        coinCount += amount;
        levelGecis.savedcoinCount++;
        UpdateCoinUI();
    }

    public int GetCoinCount()
    {
        return coinCount;
    }

    public void UpdateCoinUI()
    {
        if (coinText != null)
        {
            coinText.text = coinCount.ToString();
        }

    }
}
