using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed;
    private Rigidbody rb;

    private float x, z;

    private void Start()
    {
        rb = GetComponentInChildren<Rigidbody>();
    }

    private void Update()
    {
        Inputs();
    }

    void Inputs()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
    }
    private void FixedUpdate()
    {
        Vector3 newVel = new Vector3(x, 0, z);
        var clampVel = Vector3.ClampMagnitude(newVel * (speed * Time.fixedTime), maxSpeed);
        rb.velocity = clampVel;
    }
}
