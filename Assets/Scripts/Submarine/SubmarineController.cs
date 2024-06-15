using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement; // Tambahkan ini untuk mengatur scene
using UnityEngine.UI; // Tambahkan ini untuk mengakses UI

public class SubmarineController : MonoBehaviour
{
    // Kecepatan gerakan
    public float verticalSpeed = 5.0f;
    public float horizontalSpeed = 5.0f;
    public float speedBoostMultiplier = 2.0f;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private AudioSource turbineSound; // Referensi ke AudioSource
    private bool facingRight = true;
    private bool isMoving = false;
    private bool gameIsOver = false; // Menandakan apakah permainan sudah berakhir

    public GameObject gameOverUI; // Referensi ke UI Game Over

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        turbineSound = GetComponent<AudioSource>(); // Inisialisasi AudioSource

        // Sembunyikan UI Game Over saat mulai
        gameOverUI.SetActive(false);

        // Lock rotation on the Z axis to prevent flipping
        rb.freezeRotation = true;
    }

    void Update()
    {
        if (!gameIsOver)
        {
            HandleMovement();
            HandleTurbineSound();
        }
    }

    void HandleMovement()
    {
        float verticalInput = Input.GetAxisRaw("Vertical"); // W/S atau Tombol Panah Atas/Bawah
        float horizontalInput = Input.GetAxisRaw("Horizontal"); // A/D atau Tombol Panah Kiri/Kanan
        bool isBoosting = Input.GetKey(KeyCode.Space); // Tombol Spasi

        // Hitung arah dan kecepatan gerakan
        Vector2 movement = new Vector2(horizontalInput * horizontalSpeed, verticalInput * verticalSpeed);

        if (isBoosting)
        {
            movement *= speedBoostMultiplier;
        }

        // Terapkan gerakan
        rb.velocity = movement;

        // Handle flipping
        if (horizontalInput > 0 && !facingRight)
        {
            Flip();
        }
        else if (horizontalInput < 0 && facingRight)
        {
            Flip();
        }

        // Cek apakah kapal selam sedang bergerak
        isMoving = movement != Vector2.zero;
    }

    void HandleTurbineSound()
    {
        if (isMoving && !turbineSound.isPlaying)
        {
            turbineSound.Play(); // Mulai suara turbin
        }
        else if (!isMoving && turbineSound.isPlaying)
        {
            turbineSound.Stop(); // Hentikan suara turbin
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // Logika untuk mengakhiri permainan
            EndGame();
        }
    }

    void EndGame()
    {
        // Hentikan suara turbin jika sedang bermain
        turbineSound.Stop();

        // Tampilkan UI Game Over
        gameOverUI.SetActive(true);
        
        // Set gameIsOver menjadi true untuk menghentikan input player
        gameIsOver = true;

        // Alternatif: Anda bisa menambahkan logika lain seperti menghentikan waktu, dll.

        // Contoh: restart scene saat ini bisa diaktifkan oleh UI Game Over

        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Fungsi ini dipanggil oleh tombol "Retry" di UI Game Over
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
