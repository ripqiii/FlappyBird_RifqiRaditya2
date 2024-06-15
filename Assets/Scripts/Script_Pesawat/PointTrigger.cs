using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointTrigger : MonoBehaviour
{
    private AudioSource pointAudio;

    void Start()
    {
        pointAudio = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (pointAudio != null)
            {
                pointAudio.Play();
            }
        }
    }
}