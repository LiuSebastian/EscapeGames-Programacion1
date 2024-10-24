using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Gimball : MonoBehaviour
{
    [SerializeField] private float velocidadRotacion;
    private Rigidbody rb;
    Quaternion rotation;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        var newVel = velocidadRotacion * Time.fixedDeltaTime;
        // Rotación en el eje Y

        if (Input.GetKey(KeyCode.UpArrow))
        {
            //transform.RotateAround();
            transform.Rotate(Vector3.forward * velocidadRotacion * Time.deltaTime);
            //rb.rotation = Quaternion.Euler(rb.rotation.x + newVel, 0, rb.rotation.z);
            //rotation = Quaternion.Euler(rb.rotation.x + newVel, 0, rb.rotation.z);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Rotate(-Vector3.forward * velocidadRotacion * Time.deltaTime);
            //rb.rotation = Quaternion.Euler(rb.rotation.x - newVel, 0, rb.rotation.z);
            //rotation = Quaternion.Euler(rb.rotation.x - newVel, 0, rb.rotation.z);
        }

        // Rotación en otro eje (por ejemplo, el eje X)
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.right * velocidadRotacion * Time.deltaTime);
            //rb.rotation = Quaternion.Euler(rb.rotation.x, 0, rb.rotation.z);
            //rotation = Quaternion.Euler(rb.rotation.x, 0, rb.rotation.z + newVel);
        }
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(-Vector3.right * velocidadRotacion * Time.deltaTime);
            //rb.rotation = Quaternion.Euler(rb.rotation.x, 0, rb.rotation.z);
            //rotation = Quaternion.Euler(rb.rotation.x, 0, rb.rotation.z - newVel);
        }
    }

    void Rotate(Quaternion angle)
    {

    }
    private void FixedUpdate()
    {
        //rb.MoveRotation(rotation.normalized);
        rb.rotation = rotation.normalized;
    }
}
