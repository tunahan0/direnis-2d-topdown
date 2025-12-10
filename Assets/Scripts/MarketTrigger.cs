using UnityEngine;

public class MarketTrigger : MonoBehaviour
{
    public GameObject marketUI; // UI paneli
    private bool isPlayerNear = false;

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            marketUI.SetActive(!marketUI.activeSelf); // Aç/kapa
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            marketUI.SetActive(false); // Çýkýnca market kapanýr
        }
    }
}
