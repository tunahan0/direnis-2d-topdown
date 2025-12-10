using TMPro;
using Unity.Mathematics.Geometry;
using UnityEngine;
using UnityEngine.UI;


public class NewMonoBehaviourScript : MonoBehaviour
{
    public TextMeshProUGUI hpBarText;
    public Slider healthSlider;
    public HealthBar healthBar;
    public ShieldBar shieldBar;


    Animator anim;
    Rigidbody2D rb;

    public int MaxHealth { get; set; }
    public int CurrentHealth { get; set; }
    bool dead = false;


    float moveHorizontal, moveVertical;
    Vector2 movement;
    int facingDirection = 1;

    void Start()
    {

        MaxHealth = levelGecis.savedHealth;


        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        CurrentHealth = MaxHealth;

        healthSlider.maxValue = MaxHealth;
        healthSlider.value = CurrentHealth;
        UpdateHPBarText();
    }

    void Update()
    {
        if (dead)
        {
            movement = Vector2.zero;
            anim.SetFloat("velocity", 0);
            return;
        }

        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");

        movement = new Vector2(moveHorizontal, moveVertical).normalized;
        anim.SetFloat("velocity", movement.magnitude);

        if (movement.x != 0)
            facingDirection = movement.x > 0 ? 1 : -1;

        transform.localScale = new Vector2(facingDirection, 1);
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = movement * levelGecis.savedMoveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null && !dead)
        {
            Hit(1);
        }
    }

    void Hit(int damage)
    {

        if(levelGecis.savedShield == 0)
        {
            anim.SetTrigger("hit");

            CurrentHealth -= damage;
            CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);

            healthSlider.value = CurrentHealth;
            UpdateHPBarText();

            if (CurrentHealth <= 0)
                Die();
        }
        else
        {
            levelGecis.savedShield -= damage;
            shieldBar.UpdateShield();
        }

        
    }

    public void LifeSteal(int damage)
    {
        if (levelGecis.savedLifeSteal <= 0)
        {
            levelGecis.savedLifeSteal = 0;
            return;
        }

        bool sonuc = Random.value < 0.3f; // %30 olasılık

        if (sonuc)
        {
            int healAmount = Mathf.FloorToInt(damage * levelGecis.savedLifeSteal / 20f);
            CurrentHealth += healAmount;
            CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);

            Debug.Log("can yenilendi : " + healAmount);

            healthBar.SetHealth(CurrentHealth);
        }
        else
        {
            Debug.Log("can yenileme yok şansızlık");
        }

    }

    void UpdateHPBarText()
    {
        hpBarText.text = $"{CurrentHealth} / {MaxHealth}";
    }

    public void Die()
    {
        dead = true;
        rb.linearVelocity = Vector2.zero;

        // Collider kapatılırsa çarpışma olmaz
        Collider2D col = GetComponent<Collider2D>();
        if (col != null) col.enabled = false;

        // GameManager kontrolü
        if (GameManager.instance != null)
            GameManager.instance.GameOver();
        else
            Debug.LogWarning("GameManager instance bulunamadı!");
    }

    // MARKET'İN KULLANACAĞI FONKSİYON
    public void IncreaseMaxHealth(int amount)
    {
        MaxHealth += amount;
        CurrentHealth += amount;

        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);

        healthSlider.maxValue = MaxHealth;
        healthSlider.value = CurrentHealth;
        UpdateHPBarText();
    }
}
