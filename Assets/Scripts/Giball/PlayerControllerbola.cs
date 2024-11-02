using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using static UnityEditor.Progress;

public class PlayerControllerbola : InteractObject
{
    public float speed = 0;
    Item item;
    //[SerializeField] AudioSource sonidoGirar;

    private Rigidbody rb;
    
    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        item = GetComponent<Item>();
        
        
    }

    private void OnMoveBola(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;

        //sonidoGirar.Play();
    }

   


    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("llegada"))
        {
            
            
        }
       
    }
    public override void Interact(PlayerViewController player)
    {
        var inventory = player.GetInventory();
        PickUp(inventory);
        inventory.PickUpItem(item);
    }
}
