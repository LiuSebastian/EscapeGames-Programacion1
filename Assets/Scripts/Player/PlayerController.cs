using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float crouchSpeed;
    private float x, z;
    private Rigidbody rb;
    

    [SerializeField] private bool isGrounded;

    [SerializeField] float gravity = -30f;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;

    [SerializeField] private Transform camera;

    private bool onInteract = false;
    private bool isCrouching;
    private void Start()
    {
        rb = GetComponentInChildren<Rigidbody>();
    }

    private void Update()
    {
        if(!onInteract) Inputs();
    }

    void Inputs()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        Crouch(Input.GetKey(KeyCode.LeftControl));
    }
    private void FixedUpdate()
    {
        UpdateMove();
    }
    void UpdateMove()
    {
        Vector3 newVel = transform.right * x + transform.forward * z;
        if (!isCrouching)
        {
            newVel = Vector3.ClampMagnitude(newVel * (speed * Time.fixedDeltaTime), maxSpeed);
            newVel.y = rb.velocity.y;
        }
        else
        {
            newVel = Vector3.ClampMagnitude(newVel * (crouchSpeed * Time.fixedDeltaTime), maxSpeed);
            newVel.y = rb.velocity.y;
        }
        rb.velocity = newVel;
    }

    public void OnInteract(bool state)
    {
        onInteract = state;
    }
    void Crouch(bool crouching)
    {
      
        isCrouching = crouching;
        if(crouching) camera.transform.localPosition = new Vector3(0, 0, 0);
        else camera.transform.localPosition = new Vector3(0, 0.5f, 0);
    }
}
