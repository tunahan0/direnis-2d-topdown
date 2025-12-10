using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI hpText; 

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        UpdateHPText(health, health);
    }

    public void SetHealth(int health)
    {
        slider.value = health;
        UpdateHPText(health, (int)slider.maxValue);
    }

    private void UpdateHPText(int current, int max)
    {
        hpText.text = current + " / " + max;
    }
}
