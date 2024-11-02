using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using Color = UnityEngine.Color;

public class panel1 : InteractObject
{

    [SerializeField] Animator animator;
    [SerializeField] Light luz;
    [SerializeField] Color colorLuzOriginal;
    public bool estaprendida   = false;

    public override void Interact(PlayerViewController player)
    {
        if (estaprendida)
        {
            Apagar();
        }
        else
        {
            Prender();
        }

    }

    void Apagar()
    {
        animator.Play("apagar");
        
        //luz.color = colorLuzOriginal;
    }

    void Prender()
    {
        animator.Play("prender");
        
    }
    void LuzRojaPrenedr()
    {
        luz.color = Color.red;
        estaprendida = true;
    }
    void LuzRojaApagar()
    {
        estaprendida = false;
        luz.color = colorLuzOriginal;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
