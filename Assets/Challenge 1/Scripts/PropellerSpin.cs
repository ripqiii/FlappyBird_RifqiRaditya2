using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellerSpin : MonoBehaviour
{
    public float spinSpeed = 1000f;
    private AudioSource propellerSound;

    // Start is called before the first frame update
    void Start()
    {
        propellerSound = GetComponent<AudioSource>();
         if (propellerSound != null)
        {
            // Memainkan suara baling-baling
            propellerSound.Play();
        }
    }

    void Update()
    {
        transform.Rotate(Vector3. forward, spinSpeed * Time.deltaTime);
    }
}
