using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InteractObject : MonoBehaviour
{
    [SerializeField] private GameObject outline;
    public virtual void OnInteractRange(bool onSee)
    {
        outline.SetActive(onSee);
    }
    public virtual void Interact(){}
}
