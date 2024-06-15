using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public float speed = 10.0f;
    public float tiltSpeed = 50.0f;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       transform.Translate(Vector3.forward * speed * Time.deltaTime);

        float tiltInput = Input.GetAxis("Vertical");
        transform.Rotate(Vector3.right, -tiltInput * tiltSpeed * Time.deltaTime);
    }
}
