using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InteractObject : MonoBehaviour
{
    public virtual void Interact(PlayerViewController player){}

    public virtual void PickUp(Inventory inventory)
    {
        gameObject.SetActive(false);
    }
}
