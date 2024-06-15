using UnityEngine;

public class KapalSelam : MonoBehaviour
{
    // Jarak minimal di mana peringatan harus dimunculkan
    public float jarakPeringatan = 10f;

    // AudioSource untuk suara peringatan
    public AudioSource suaraPeringatan;

    // AudioSource untuk suara turbin
    public AudioSource suaraTurbin;

    // Rigidbody kapal selam
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (suaraPeringatan == null || suaraTurbin == null)
        {
            Debug.LogError("AudioSource belum diassign.");
        }
    }

    void Update()
    {
        if (suaraPeringatan == null || suaraTurbin == null)
        {
            return;
        }

        // Mengecek semua objek dengan tag "Obstacle" yang berada dalam jarak peringatan
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");

        bool isNearObstacle = false;

        foreach (GameObject obstacle in obstacles)
        {
            float jarak = Vector3.Distance(transform.position, obstacle.transform.position);
            Debug.Log($"Jarak ke obstacle: {jarak}");

            if (jarak <= jarakPeringatan)
            {
                isNearObstacle = true;
                if (!suaraPeringatan.isPlaying)
                {
                    Debug.Log("Memutar suara peringatan.");
                    suaraPeringatan.Play();
                }
                break;
            }
        }

        if (!isNearObstacle && suaraPeringatan.isPlaying)
        {
            Debug.Log("Menghentikan suara peringatan.");
            suaraPeringatan.Stop();
        }

        // Memeriksa input dari pemain
        bool isInputMoving = Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0 || Input.GetAxis("Depth") != 0;
        // Memeriksa kecepatan kapal selam
        bool isVelocityMoving = rb.velocity.magnitude > 0.1f;

        // Debugging log untuk input dan kecepatan
        Debug.Log($"isInputMoving: {isInputMoving}, isVelocityMoving: {isVelocityMoving}, rb.velocity: {rb.velocity}");

        bool isMoving = isInputMoving || isVelocityMoving;

        if (isMoving)
        {
            if (!suaraTurbin.isPlaying)
            {
                Debug.Log("Memutar suara turbin.");
                suaraTurbin.Play();
            }
        }
        else
        {
            if (suaraTurbin.isPlaying)
            {
                Debug.Log("Menghentikan suara turbin.");
                suaraTurbin.Stop();
            }
        }
    }
}
