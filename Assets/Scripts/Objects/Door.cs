using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private bool openDoor = false;
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (openDoor)
        {
            OpenDoor();
        }
    }

    public void OpenDoor()
    {
        animator.Play("Door_Open");
    }
}
