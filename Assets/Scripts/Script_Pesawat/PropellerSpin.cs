using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellerSpin : MonoBehaviour
{
    public float spinSpeed = 1000f;
    private AudioSource propellerSound;

    void Start()
    {
        propellerSound = GetComponent<AudioSource>();
         if (propellerSound != null)
        {
            propellerSound.Play();
        }
    }

    void Update()
    {
        transform.Rotate(Vector3. forward, spinSpeed * Time.deltaTime);
    }
}
