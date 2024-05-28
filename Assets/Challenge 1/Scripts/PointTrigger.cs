using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointTrigger : MonoBehaviour
{
    // Referensi ke komponen AudioSource
    private AudioSource pointAudio;

    void Start()
    {
        // Mendapatkan komponen AudioSource
        pointAudio = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        // Memastikan yang melewati trigger adalah pesawat
        if (other.CompareTag("Player"))
        {
            // Memainkan suara poin
            if (pointAudio != null)
            {
                pointAudio.Play();
            }
        }
    }
}