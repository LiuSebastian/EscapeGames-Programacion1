using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum KeyType
{
    SimpleKey
}
public class Key : InteractObject
{
    private Item item;

    private void Start()
    {
        item = GetComponent<Item>();
    }

    public override void Interact(PlayerViewController player)
    {
        var inventory = player.GetInventory();
        PickUp(inventory);
        inventory.PickUpItem(item);
    }
}
