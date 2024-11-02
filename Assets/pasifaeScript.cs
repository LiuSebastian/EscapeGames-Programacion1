using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pasifaeScript : InteractObject
{
    [SerializeField] Material Material;
    [SerializeField] Material Material1;
    [SerializeField] Material Material2;
    [SerializeField] Material Material3;

    [SerializeField] Animator animator;
    [SerializeField] MeshRenderer meshRenderer;

    [SerializeField] AudioSource engranaje;

    int vueltas = 1;
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer.material = Material2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Interact(PlayerViewController player)
    {
        Girar();
    }
    void Girar()
    {
        if (vueltas == 0)
        {
            animator.Play("giro1");
            SetMaterial(vueltas);
            vueltas++;
        }
        else if (vueltas == 1)
        {
            animator.Play("giro2");
            SetMaterial(vueltas);
            vueltas++;
        }
        else if (vueltas == 2)
        {
            animator.Play("giro3");
            SetMaterial(vueltas);
            vueltas++;
        }
        else
        {
            animator.Play("giro4");
            SetMaterial(vueltas);
            vueltas = 0;
        }
        engranaje.Play();
    }
    void SetMaterial(int numero)
    {
        List<Material> materiales = new List<Material> { Material, Material1, Material2, Material3 };
        meshRenderer.material = materiales[numero];
    }
}
