using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Cinemachine;
using System.Drawing;

public class controlCajaFuerte : InteractObject
{
      // Asigna el Input Field desde el Inspector
    public GameObject cajaFuerte;
    public Animator puerta;
    private bool estaAbierta = false;
    [SerializeField] string clave;
    [SerializeField] Canvas canvas;
    [SerializeField] CinemachineVirtualCamera cameara;
    [SerializeField] TMP_InputField inputField;
    [SerializeField] TMP_Text mensajes;
    string mensaje1 = "Clave correcta!";
    string mensaje2 = "Clave incorrecta, intenta nuevamente.";


    //en el interactuar pregunta si esta abierta aplica la animacion cerrar

    public override void Interact(PlayerViewController player)
    {

        if (estaAbierta)
        {
            cameara.Priority = 0;
            inputField.DeactivateInputField();
            cerrar();
        }
        else
        {
            cameara.Priority = 3;
            
            inputField.ActivateInputField();
            

        }


    }

    

    public void VerificarPalabra()
    {
        string textoIngresado = inputField.text;
        
        // Verifica si la palabra ingresada es "Rubik"
        if (textoIngresado.Equals(clave, System.StringComparison.OrdinalIgnoreCase))
        {
            mensajes.color = UnityEngine.Color.green;
            mensajes.text = mensaje1;
            Invoke("Borrar", 1f);
            Debug.Log("¡Palabra correcta! Abriendo la caja fuerte...");
            inputField.DeactivateInputField();
            AbrirCajaFuerte();  // Llama a la función para abrir la caja fuerte
        }
        else
        {
            mensajes.color = UnityEngine.Color.red;
            mensajes.text = mensaje2;
            Invoke("Borrar", 2f);
            inputField.text = "";
            inputField.ActivateInputField();
        }
    }
    public void cerrar()
    {
        puerta.Play("Cerrar");
        inputField.DeactivateInputField();
    }
    private void AbrirCajaFuerte()
    {
        puerta.Play("Abrir");
        estaAbierta=true;
        cameara.Priority = 0;
        //transform.Find("botones").gameObject.SetActive(false);
        // Aquí puedes poner la lógica para abrir la caja fuerte, como activar una animación o mover un objeto.
        //cajaFuerte.SetActive(false);  // Ejemplo: desactiva la caja fuerte
    }

    private void Borrar()
    {
        mensajes.text =string.Empty;

    }

    
}
