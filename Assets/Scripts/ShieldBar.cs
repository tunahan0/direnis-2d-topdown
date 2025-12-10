using UnityEngine;
using UnityEngine.UI;


public class ShieldBar : MonoBehaviour
{
    public Slider slider;


    public void SetShield(int savedShield)
    {
        slider.maxValue = 5;
        slider.value = savedShield;
    }
    public void UpdateShield()
    {
        slider.value = levelGecis.savedShield;
    }
}
