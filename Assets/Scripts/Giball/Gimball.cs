using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Gimball : InteractObject
{
    //
    [SerializeField] Transform starting;
    [SerializeField] GameObject bola;
    [SerializeField] CinemachineVirtualCamera cameara;
    bool estaActivo= false;
    PlayerViewController _player;
    private void Start()
    {
        bola.transform.position = starting.position;
        //sonido1.Play();
    }
    public override void Interact(PlayerViewController player)
    {
        if (_player == null)
        {
            _player = player;

        }
        if (!estaActivo)
        {
            cameara.Priority = 3;
            estaActivo = true;
            _player.OnInteract(true);
        }
        
    }

    // _player.lockcursor(true)
    public void OnExitInteraction()
    {
        cameara.Priority = 0;
        estaActivo = false;
        _player.OnInteract(false);
    }
    private void Update()
    {
        if (estaActivo)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                OnExitInteraction();
            }
        }
        
    }
}

