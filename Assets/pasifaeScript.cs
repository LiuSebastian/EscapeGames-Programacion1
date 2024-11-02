using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pasifaeScript : MonoBehaviour
{
    [SerializeField] Material Material;
    [SerializeField] Material Material1;
    [SerializeField] Material Material2;
    [SerializeField] Material Material3;

    [SerializeField] Animator animator;
    [SerializeField] MeshRenderer meshRenderer;

    
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer.material = Material2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
