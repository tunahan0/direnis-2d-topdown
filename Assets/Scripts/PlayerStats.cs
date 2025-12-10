using JetBrains.Annotations;
using System;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class PlayerStats : MonoBehaviour
{

    public CoinManager coinManager;
    public Projectile projectile;
    public HealthBar Health;

    public NewMonoBehaviourScript player;
    public Gun gun;
    public GunManager gunManager;

    void Start()
    {
        coinManager = CoinManager.Instance;
    }

    public void ApplyUpgrade(int damageModifier, int healthModifier)
    {
        levelGecis.savedDamage += damageModifier;
        levelGecis.savedHealth += healthModifier;

        projectile.damage = levelGecis.savedDamage;
        Health.SetMaxHealth(levelGecis.savedHealth);

        //Debug.Log("Yeni Hasar: " + projectile.damage);
        //Debug.Log("Yeni Can: " + levelGecis.savedHealth);
    }

    public void ApplyUpgrade_2(float FireRateModifier, int LifeStealModifier)
    {
        levelGecis.savedFireRate /= FireRateModifier;   // çarpma kullanýldý
        levelGecis.savedLifeSteal += LifeStealModifier;
        levelGecis.savedFireRateCount *= 2;

        gun.fireRate = levelGecis.savedFireRate;
        
        
        Debug.Log("Yeni Atýþ hýzý: " + gun.fireRate);
        //Debug.Log("Yeni Can Çalma: " + levelGecis.savedLifeSteal);
    }

    public void ApplyUpgrade_3(float SpeedModifier, int ShieldModifier)
    {
        levelGecis.savedMoveSpeed += SpeedModifier;
        int shield = ShieldModifier;

        //Debug.Log("Yeni hýz: " + levelGecis.savedMoveSpeed);
        //Debug.Log("Yeni zýrh: " + shield);
    }

    public void ApplyUpgrade_4(float SpeedModifier)
    {

        levelGecis.savedGunCount++;
        gunManager.hasUpdatedGunCount = false;

        levelGecis.savedMoveSpeed += SpeedModifier;

        //Debug.Log("Yeni hýz: " + levelGecis.savedMoveSpeed);
    }

    public void ApplyUpgrade_5(int ShieldModifier)
    {
        levelGecis.savedShield += ShieldModifier;

        //Debug.Log("Yeni Can: " + levelGecis.savedShield);
    }

    public void ApplyUpgrade_6(int LifeStealModifier, int ShieldModifier)
    {
        levelGecis.savedLifeSteal += LifeStealModifier;
        levelGecis.savedShield += ShieldModifier;

        //Debug.Log("Yeni Can Çalma: " + levelGecis.savedLifeSteal);
        //Debug.Log("Yeni zýrh: " + levelGecis.savedShield);
    }

    public void ApplyUpgrade_7(int ShieldModifier,float SpeedModifier)
    {
        levelGecis.savedShield += ShieldModifier;
        levelGecis.savedMoveSpeed += SpeedModifier;

        //Debug.Log("Yeni zýrh: " + levelGecis.savedShield);
        //Debug.Log("Yeni hýz: " + levelGecis.savedMoveSpeed);
    }
    public void ApplyUpgrade_8(int healthModifier, float SpeedModifier)
    {
        levelGecis.savedHealth += healthModifier;
        levelGecis.savedMoveSpeed= SpeedModifier;

        Health.SetMaxHealth(levelGecis.savedHealth);

        //Debug.Log("Yeni Can: " + levelGecis.savedHealth);
        //Debug.Log("Yeni hýz: " + levelGecis.savedMoveSpeed);
    }


    public bool SpendMoney(int amount)
    {
        if (coinManager.coinCount >= amount)
        {
            coinManager.AddCoin(-amount);  // Parayý düþür
            levelGecis.savedcoinCount -= amount;
            coinManager.UpdateCoinUI();
            return true;
        }
        else
        {
            Debug.Log("Yetersiz bakiye!");
            return false;
        }
    }
}
