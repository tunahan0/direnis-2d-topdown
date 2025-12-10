using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneChanger2 : MonoBehaviour
{
    public void BaslangýcScene()
    {
        levelGecis.savedHealth = 20;
        levelGecis.savedDamage = 25;
        levelGecis.savedFireRate = 1f;
        levelGecis.savedMoveSpeed = 6.0f;
        levelGecis.savedShield = 0;
        levelGecis.savedLifeSteal = 0;
        levelGecis.savedGunCount = 0;

        levelGecis.savedcoinCount = 0;
        levelGecis.savedLevelCount = 1;
        levelGecis.savedLevel = 1;


        SceneManager.LoadScene(1);     // orman 1
        levelGecis.savedLevelCount += 2;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (levelGecis.savedLevelCount == 3)
        {
            if (collision.CompareTag("Player"))
            {
                SceneManager.LoadScene(3);     // orman 2
                levelGecis.savedLevelCount++;
                levelGecis.savedLevel++;
                
            }
        }
        else if (levelGecis.savedLevelCount < 6)
        {
            if (levelGecis.savedLevelCount == 4)
            {
                if (collision.CompareTag("Player"))
                {
                    SceneManager.LoadScene(4);     //çöl 1
                    levelGecis.savedLevelCount++;
                    levelGecis.savedLevel++;
                }
            }
            else if (levelGecis.savedLevelCount == 5)
            {
                if (collision.CompareTag("Player"))
                {
                    SceneManager.LoadScene(5);      //çöl 2
                    levelGecis.savedLevelCount++; 
                    levelGecis.savedLevel++;
                }
            }
        }
        else if (levelGecis.savedLevelCount < 8)
        {
            if (levelGecis.savedLevelCount == 6)
            {
                if (collision.CompareTag("Player"))
                {
                    SceneManager.LoadScene(6);
                    levelGecis.savedLevelCount++;
                    levelGecis.savedLevel++;
                }
            }
            else if (levelGecis.savedLevelCount == 7)
            {
                if (collision.CompareTag("Player"))
                {
                    SceneManager.LoadScene(7);
                    levelGecis.savedLevelCount++;
                    levelGecis.savedLevel++;
                }
            }
        }






        
    }
}

