using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] Sprite itemSprite;
    [SerializeField] string itemName;
    [SerializeField] private Rigidbody rb;
    [SerializeField] BoxCollider collider;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void OnSelectItem(bool state)
    {
        rb.isKinematic = state;
        collider.enabled = !state;
    }
    public string GetItemName()
    {
        return itemName;
    }
    public Sprite GetItemSprite()
    {
        return itemSprite;
    }
}
