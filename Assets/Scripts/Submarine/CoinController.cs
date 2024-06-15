using System.Collections;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float respawnTime = 5.0f;  // Waktu untuk respawn coin
    private float timer;  // Timer untuk menghitung waktu respawn
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        SpawnCoin();
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            RespawnCoin();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CoinCollected();
        }
    }

    private void CoinCollected()
    {
        // Mainkan efek suara
        audioSource.Play();

        // Nonaktifkan koin dan jadwalkan respawn
        gameObject.SetActive(false);
        Invoke("RespawnCoin", audioSource.clip.length);
    }

    private void RespawnCoin()
    {
        Vector2 randomPosition = GetRandomPosition();
        transform.position = randomPosition;
        gameObject.SetActive(true);
        timer = respawnTime;
    }

    private void SpawnCoin()
    {
        Vector2 initialPosition = GetRandomPosition();
        transform.position = initialPosition;
        gameObject.SetActive(true);
        timer = respawnTime;
    }

    private Vector2 GetRandomPosition()
    {
        // Misalnya kita menggunakan area (x: -5 hingga 5, y: -5 hingga 5) untuk coin muncul
        float randomX = Random.Range(-360.0f, -160.0f);
        float randomY = Random.Range(250.0f, 320.0f);
        return new Vector2(randomX, randomY);
    }
}
