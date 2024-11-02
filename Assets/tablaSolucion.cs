using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class tablaSolucion : InteractObject
{
    private Item item;

    // Start is called before the first frame update
    void Start()
    {
        item = GetComponent<Item>();
    }
    public override void Interact(PlayerViewController player)
    {
        var inventory = player.GetInventory();
        PickUp(inventory);
        inventory.PickUpItem(item);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
