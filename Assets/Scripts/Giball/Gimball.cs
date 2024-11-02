using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Gimball : InteractObject
{
    [SerializeField] Transform starting;
    [SerializeField] GameObject bola;
    [SerializeField] CinemachineVirtualCamera cameara;
    bool estaActivo= false;
    private void Start()
    {
        bola.transform.position = starting.position;
    }
    public override void Interact(PlayerViewController player)
    {
        
        if (estaActivo)
        {
            cameara.Priority = 0;
            estaActivo = false;
        }
        else
        {
            cameara.Priority = 3;
            estaActivo = true;
        }


    }


}

