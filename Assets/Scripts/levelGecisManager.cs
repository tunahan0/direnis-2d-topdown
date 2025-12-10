using UnityEngine;
using TMPro;


public class levelGecis : MonoBehaviour
{

    public ShieldBar shieldBar;


    public static int savedHealth = 20;
    public static int savedDamage = 25;
    public static float savedFireRate = 1f;
    public static float savedMoveSpeed = 6.0f;
    public static int savedShield = 0;
    public static int savedLifeSteal = 0; 
    public static int savedGunCount = 0;

    public static int savedcoinCount = 0;
    public static int savedLevelCount = 1;
    public static int savedLevel = 1;


    public TMP_Text healthText;
    public TMP_Text damageText;
    public TMP_Text canCalmaText;
    public TMP_Text moveSpeedText;
    public TMP_Text shieldText;
    public TMP_Text fireRateText;
    public TMP_Text LevelCountText;


    const int minDamage = 1;
    const int maxDamage = 100;

    const float minMoveSpeed = 5f;
    const float maxMoveSpeed = 10f;

    const int minShield = 0;
    const int maxShield = 5;

    const int minLifeSteal = 0;
    const int maxLifeSteal = 20;

    public int HizText = 12;
    public int saldiriHiziText = 2;
    public static int savedFireRateCount = 1;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shieldBar.SetShield(levelGecis.savedShield);
    }

    // Update is called once per frame
    void Update()
    {
        ClampStats();
        UpdateUI();
    }

    void ClampStats()
    {
        savedDamage = Mathf.Clamp(savedDamage, minDamage, maxDamage);
        savedMoveSpeed = Mathf.Clamp(savedMoveSpeed, minMoveSpeed, maxMoveSpeed);
        savedShield = Mathf.Clamp(savedShield, minShield, maxShield);
        savedLifeSteal = Mathf.Clamp(savedLifeSteal, minLifeSteal, maxLifeSteal);
    }

    void UpdateUI()
    {
        HizText = (int)(savedMoveSpeed * 2);
        saldiriHiziText = savedFireRateCount * 2;

        healthText.text = savedHealth.ToString();
        damageText.text = savedDamage.ToString();
        canCalmaText.text = savedLifeSteal.ToString();
        moveSpeedText.text = HizText.ToString();
        shieldText.text = savedShield.ToString();
        fireRateText.text = saldiriHiziText.ToString();
        LevelCountText.text = savedLevel.ToString();
    }

    public void reset()
    {
        savedHealth = 20;
        savedDamage = 25;
        savedFireRate = 1f;
        savedMoveSpeed = 6.0f;
        savedShield = 0;
        savedLifeSteal = 0; 
        savedGunCount = 0;

        savedcoinCount = 0;
        savedLevelCount = 1;
        savedLevel = 1;
    }
}
