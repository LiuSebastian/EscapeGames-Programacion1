using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Sprite itemSprite;
    [SerializeField] string itemName;
    [SerializeField] private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }
    public void OnSelectItem(bool state)
    {
        rb.isKinematic = state;
        rb.detectCollisions = !state;
    }
    public string GetItemName()
    {
        return itemName;
    }
    public Sprite GetItemSprite()
    {
        return itemSprite;
    }

    public void PlayAnimation(string onhand)
    {
        animator.Play(onhand);
    }
}
