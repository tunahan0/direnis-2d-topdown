using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    [SerializeField] GameObject gunPrefab;

    Transform player;
    List<Vector2> gunPositions = new List<Vector2>();

    public TMP_Text messageText;
    public bool hasUpdatedGunCount = false;

    int spawnedGuns = 0;

    private void Start()
    {
        player = GameObject.Find("Player").transform;

        gunPositions.Add(new Vector2(-1.2f, 1f));
        gunPositions.Add(new Vector2(1.2f, 1f));

        gunPositions.Add(new Vector2(-1.4f, 0.2f));
        gunPositions.Add(new Vector2(1.4f, 0.2f));

        gunPositions.Add(new Vector2(-1f, -0.5f));
        gunPositions.Add(new Vector2(1f, -0.5f));

        hasUpdatedGunCount = false;
        AddGun();
    }

    public void Update()
    {
        if (!hasUpdatedGunCount && levelGecis.savedGunCount > 0)
        {
            AddGunModifier();
            hasUpdatedGunCount = true;  // Güncelleme bir kere yapýlacak
        }

        //For Testing
        if (Input.GetKeyUp(KeyCode.G))
        {
            AddGun();
        }
    }

    public void AddGunModifier()
    {
        for (int i = 0; i < levelGecis.savedGunCount; i++)  // savedGunCount kadar silah ekleyin
        {
            AddGun();
        }
    }

    public void AddGun()
    {
        if (spawnedGuns >= gunPositions.Count)
        {
            ShowMessage("max silah sayýsýna ulaþýldý!");
            Debug.LogWarning("Tüm silah pozisyonlarý dolu, yeni silah eklenemiyor.");
            return;
        }

        var pos = gunPositions[spawnedGuns];
        var newGun = Instantiate(gunPrefab, pos, Quaternion.identity);
        newGun.GetComponent<Gun>().SetOffset(pos);
        spawnedGuns++;
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
