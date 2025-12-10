using UnityEngine;
using UnityEngine.UI;

public class SesAyarController : MonoBehaviour
{
    public GameObject ayarlarPaneli;
    public Slider sesSlider;

    private void Start()
    {
        sesSlider.value = AudioListener.volume;
        sesSlider.onValueChanged.AddListener(SesDegistir);
        ayarlarPaneli.SetActive(false);
    }

    public void AyarlariAc()
    {
        ayarlarPaneli.SetActive(true);
    }

    public void AyarlariKapat()
    {
        ayarlarPaneli.SetActive(false);
    }

    public void SesDegistir(float deger)
    {
        AudioListener.volume = deger;
    }
}
