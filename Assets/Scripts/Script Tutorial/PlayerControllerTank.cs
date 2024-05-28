using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerTank : MonoBehaviour
{
    private float speed = 5.0f;
    private float turnSpeed = 35.0f;
    private float horizontalInput;
    private float forwardInput;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        //Move the vehicle Forward base on vertical input
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        //Move the vehicle Forward base on horizontal input
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
    }
}
