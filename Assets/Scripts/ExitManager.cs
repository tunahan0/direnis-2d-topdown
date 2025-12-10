using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitManager : MonoBehaviour
{
    public GameObject gameOverPanel;

    public AudioClip clickSound;       // Buton sesi
    public AudioClip gameOverMusic;    // Bitiþ ekraný müziði

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
        PlayGameOverMusic();
    }

    public void LoadMenu()
    {
        StopMusic();
        PlayClickSound();
        Time.timeScale = 1f;
        SceneManager.LoadScene("BaslangicEkrani");
    }

    public void QuitGame()
    {
        StopMusic();
        PlayClickSound();
        Application.Quit();
        Debug.Log("Oyun kapandý (Editörde görünmez).");
    }

    private void PlayClickSound()
    {
        if (clickSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(clickSound);
        }
    }

    private void PlayGameOverMusic()
    {
        if (gameOverMusic != null && audioSource != null)
        {
            audioSource.clip = gameOverMusic;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    private void StopMusic()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}
