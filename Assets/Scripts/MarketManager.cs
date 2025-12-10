using TMPro;
using UnityEngine;


public class MarketManager : MonoBehaviour
{
    public PlayerStats playerStats;
    public TMP_Text messageText;

    public int cehennemYumruguPrice = 20;
    public int cehennemYumruguDamageBonus = 3;
    public int cehennemYumruguHealthPenalty = -2;

    public int yildirimPencesiPrice = 35;
    public float yildirimPencesiFireRate = 2f;
    public int yildirimPencesiCanCalma = -2;

    public int HizPeleriniPrice = 30;
    public float HizPeleriniHiz = 2f;
    public int HizPeleriniZirh = -1;

    public int EkstraSilahPrice = 10;
    public float EkstraSilahHiz = -1f;

    public int CelikKirbaciPrice = 25;
    public int CelikKirbaciZirh = 3;

    public int ZehirliPencePrice = 20;
    public int ZehirliPenceCanCalma = 2;
    public int ZehirliPenceZirh = -1;

    public int DemirKabukPrice = 30;
    public int DemirKabukZirh = 2;
    public float DemirKabukHiz = -1f;

    public int AzamiSaglikPrice = 30;
    public int AzamiSaglikCan = 3;
    public float AzamiSaglikHiz = -1f;


    public void BuyCehennemYumrugu()
    {
        if (playerStats.SpendMoney(cehennemYumruguPrice))
        {
            playerStats.ApplyUpgrade(cehennemYumruguDamageBonus, cehennemYumruguHealthPenalty);
            ShowMessage("Cehennem Yumruðu satýn alýndý!");
        }
        else
        {
            ShowMessage("Yetersiz bakiye!");
        }
    }

    public void BuyyildirimPencesi()
    {
        if (playerStats.SpendMoney(yildirimPencesiPrice))
        {
            playerStats.ApplyUpgrade_2(yildirimPencesiFireRate,yildirimPencesiCanCalma);
            ShowMessage("Yýldýrým pençesi satýn alýndý!");
        }
        else
        {
            ShowMessage("Yetersiz bakiye!");
        }
    }

    public void BuyHizPelerini()
    {
        if (playerStats.SpendMoney(HizPeleriniPrice))
        {
            playerStats.ApplyUpgrade_3(HizPeleriniHiz, HizPeleriniZirh);
            ShowMessage("Hýz Pelerini satýn alýndý!");
        }
        else
        {
            ShowMessage("Yetersiz bakiye!");
        }
    }
    
    public void BuyEkstraSilah()
    {
        if (playerStats.SpendMoney(EkstraSilahPrice))
        {
            playerStats.ApplyUpgrade_4(EkstraSilahHiz);
            ShowMessage("Ekstra silah satýn alýndý!");
        }
        else
        {
            ShowMessage("Yetersiz bakiye!");
        }
    }

    public void BuyCelikKirbaci()
    {
        if (playerStats.SpendMoney(CelikKirbaciPrice))
        {
            playerStats.ApplyUpgrade_5(CelikKirbaciZirh);
            ShowMessage("Çelik kýrbacý satýn alýndý!");
        }
        else
        {
            ShowMessage("Yetersiz bakiye!");
        }
    }

    public void BuyZehirliPence()
    {
        if (playerStats.SpendMoney(ZehirliPencePrice))
        {
            playerStats.ApplyUpgrade_6(ZehirliPenceCanCalma, ZehirliPenceZirh);
            ShowMessage("Zehirli pençe satýn alýndý!");
        }
        else
        {
            ShowMessage("Yetersiz bakiye!");
        }
    }
    public void BuyDemirKabuk()
    {
        if (playerStats.SpendMoney(DemirKabukPrice))
        {
            playerStats.ApplyUpgrade_7(DemirKabukZirh, DemirKabukHiz);
            ShowMessage("Demir kabuk satýn alýndý!");
        }
        else
        {
            ShowMessage("Yetersiz bakiye!");
        }
    }

    public void BuyAzamiSaglik()
    {
        if (playerStats.SpendMoney(AzamiSaglikPrice))
        {
            playerStats.ApplyUpgrade_8(AzamiSaglikCan, AzamiSaglikHiz);
            ShowMessage("Azami saðlýk satýn alýndý!");
        }
        else
        {
            ShowMessage("Yetersiz bakiye!");
        }
    }
    public void ShowMessage(string msg)
    {
        messageText.text = msg;
        CancelInvoke("ClearMessage"); // Süre dolmadan tekrar gösterilirse temizleme iptal edilir
        Invoke("ClearMessage", 2f);   // 2 saniye sonra temizle
    }

    void ClearMessage()
    {
        messageText.text = "";
    }
}
