using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using Color = UnityEngine.Color;

public class panel1 : InteractObject
{

    [SerializeField] Animator animator;
    //[SerializeField] Light luz;
    //[SerializeField] Color colorLuzOriginal;
    public bool estaprendida   = true;
    [SerializeField] bool codigo;
    [SerializeField] int orden;
    [SerializeField] PanelmanagerScrp contra;
    [SerializeField] AudioSource audioasd;

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
        animator.Play("prender");
        audioasd.Play();
        estaprendida = false;
        contra.contrasenia[orden] = estaprendida;
        contra.ComprobarContrasenia();
        
        //luz.color = colorLuzOriginal;
    }

    void Prender()
    {
        animator.Play("apagar");
        audioasd.Play();
        estaprendida = true;
        contra.contrasenia[orden] = estaprendida;
        contra.ComprobarContrasenia();
        

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
