using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IElectric
{
    [SerializeField] private bool openDoor = false;
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void OpenDoor()
    {
        animator.Play("Door_Open");
    }

    public void Open()
    {
        OpenDoor();
    }

    public void Close()
    {

    }
}
