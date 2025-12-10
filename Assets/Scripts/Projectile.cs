using UnityEngine;

public class Projectile : MonoBehaviour
{
    public NewMonoBehaviourScript player;
    public ShieldBar shieldBar;


    float speed = 18f;
    public int damage = 25;


    public void Start()
    {
        damage = levelGecis.savedDamage;
    }
    private void FixedUpdate()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            Destroy(gameObject);
            enemy.Hit(damage);
            player.LifeSteal(damage);


            Debug.Log("Enemy : " + damage);
        }
    }
}
