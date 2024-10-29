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
       
    }

    void Rotate(Quaternion angle)
    {

    }
    private void FixedUpdate()
    {
        //rb.MoveRotation(rotation.normalized);
        //rb.rotation = rotation.normalized;
    }
}
