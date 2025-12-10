using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    NewMonoBehaviourScript player;
    [SerializeField] TextMeshProUGUI timeText;

    public static WaveManager Instance;
    public TMP_Text messageText;


    bool waveRunning = true;
    int currentWave = 0;
    int currentWaveTime;
    int i = 0;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    private void Start()
    {
        player = FindObjectOfType<NewMonoBehaviourScript>();
        StartNewWave();
        timeText.text = "30";

    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
            StartNewWave();
    }

    public bool WaveRunning() => waveRunning;

    private void StartNewWave()
    {
        StopAllCoroutines();
        timeText.color = Color.white;
        currentWave++;
        waveRunning = true;
        currentWaveTime = 30;
        StartCoroutine(WaveTimer());
    }

     IEnumerator WaveTimer()
    {
        while (currentWaveTime > 0)
        {
            yield return new WaitForSeconds(1f);
            currentWaveTime--;
            timeText.text = currentWaveTime.ToString();
        }

        // Sayaç sýfýra indiðinde kontrol
        if (timeText.color == Color.white)
        {
            Wavecomplete(); // Beyaz sayaç bitti, kaçýþ sürecine geç
        }
        else if (timeText.color == Color.red)
        {
            EnemyManager.Instance.DestroyAllEnemies();
            waveRunning = false;
            player.Die();   // Kýrmýzý sayaç da bitti, oyuncu ölür
        }
    }
    private void Wavecomplete()
    {
        StopAllCoroutines(); // Var olan sayacý durdur

        currentWaveTime = 15;
        timeText.text = currentWaveTime.ToString();
        timeText.color = Color.red;
        if(i == 0)
        {
            ShowMessage("Kaçmak için son 15 saniye ACELE ET!!!");
            i++;
        }

        StartCoroutine(WaveTimer()); // Yeni sayaç baþlat
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
