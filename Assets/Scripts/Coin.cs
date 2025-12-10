using UnityEngine;

public class Coin : MonoBehaviour
{
    public float attractionRange = 3f; // Oyuncuya yaklaþma mesafesi
    public float moveSpeed = 5f;       // Yaklaþma hýzý

    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance < attractionRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Çarpýþma algýlandý: " + other.name);
            FindFirstObjectByType<CoinManager>().AddCoin(1);
            Destroy(gameObject);
        }
    }
}
