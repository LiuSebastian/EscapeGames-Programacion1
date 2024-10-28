using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractCube : InteractObject
{
    private MeshRenderer mr;
    private Material mat;

    [SerializeField] private bool isLocked = true;
    private void Start()
    {
        mr = GetComponent<MeshRenderer>();
        mat = mr.material;
    }

    public override void Interact(PlayerViewController player)
    {
        if (isLocked)
        {
            mat.color = Color.red;
            isLocked = false;
        }
        else
        {
            mat.color = Color.black;
            isLocked = true;
        }
    }
}
