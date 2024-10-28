using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class controlCajaFuerte : MonoBehaviour
{
    public TMP_InputField inputField;  // Asigna el Input Field desde el Inspector
    public GameObject cajaFuerte;
    public Animator puerta;
    private bool estaAbierta = false;
    [SerializeField] string clave;
    [SerializeField] Canvas canvas;

    //en el interactuar pregunta si esta abierta aplica la animacion cerrar
    public void VerificarPalabra()
    {
        string textoIngresado = inputField.text;
        
        // Verifica si la palabra ingresada es "Rubik"
        if (textoIngresado.Equals(clave, System.StringComparison.OrdinalIgnoreCase))
        {
            Debug.Log("¡Palabra correcta! Abriendo la caja fuerte...");
            AbrirCajaFuerte();  // Llama a la función para abrir la caja fuerte
        }
        else
        {
            Debug.Log("Palabra incorrecta, intenta nuevamente.");
        }
    }
    public void cerrar()
    {
        puerta.Play("Cerrar");
    }
    private void AbrirCajaFuerte()
    {
        puerta.Play("Abrir");
        estaAbierta=true;
        //transform.Find("botones").gameObject.SetActive(false);
        // Aquí puedes poner la lógica para abrir la caja fuerte, como activar una animación o mover un objeto.
        //cajaFuerte.SetActive(false);  // Ejemplo: desactiva la caja fuerte
    }
    public void Borrar()
    {
        inputField.text = "";
    }
}
